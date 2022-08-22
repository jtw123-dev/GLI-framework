using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] private enum AIState
    {
        Running,
        Death,
        CoverIdle,
    }
    [SerializeField] private Transform _startingPos;
    [SerializeField] private AIState _currentState;
    private int _currentPoint;
    [SerializeField]private float _speed;
    [SerializeField] private Transform _endPos;
    private NavMeshAgent _agent;
    private Animator _anim;
    [SerializeField] private Transform[] _coverLocations;
    [SerializeField] private int _currentCoverLocation;
    [SerializeField]private bool _death;
    [SerializeField]private bool _cover ;
    public int score;
 
    // Start is called before the first frame update
    void Start()
    {
        
        _currentState = AIState.Running;
     
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
         _agent.speed = _speed;
    }


    private void OnEnable()
    {
        _currentState = AIState.Running;

        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _agent.speed = _speed;
    }
    // Update is called once per frame
    void Update()
    {

        switch (_currentState)
        {
            case AIState.Running:
                _agent.isStopped = false;
                _anim.SetFloat( "Speed",_speed);
                CalculateMovement();
                break;

            case AIState.CoverIdle:
                if (_cover==true)
                {
                    StartCoroutine("CoverWait");
                    _cover = false;
                }
                _anim.SetBool("Hiding", true);            
                break;
            case AIState.Death:
                _anim.SetTrigger("Death");
                _agent.isStopped = true;    
                
                break;
        }     
    }

    private void CalculateMovement()
    {
        _agent.SetDestination(_coverLocations[_currentCoverLocation].transform.position);
    }

    private IEnumerator CoverWait()
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(Random.Range(3,5));
        _currentState = AIState.Running;

        if (_currentCoverLocation == _coverLocations.Length-1)
        {
            _currentCoverLocation = 0;
        }
        else
        {
            _currentCoverLocation++;
        }
        
        _anim.SetBool("Hiding", false);
        _cover = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Finish")
        {
            Recycle();
        }
        if (other.tag=="Cover")
        {
            _cover = true;
            _currentState = AIState.CoverIdle;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Cover")
        {
            _cover = false;
        }
    }

    private void Recycle()
    {
        this.gameObject.transform.position = _startingPos.position;
        _currentCoverLocation = 0;
        this.gameObject.SetActive(false);
        _speed = 10;
    }

    public void Death()
    {
        _speed = 0;
        _currentState = AIState.Death;
        score += 50;
        StartCoroutine("WaitForDeath");
    }

    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(3);
        Recycle();
    }
}

//maybe onenable