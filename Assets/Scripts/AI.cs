using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] private Transform _startingPos;
    [SerializeField] private Transform _endPos;
    private NavMeshAgent _agent;
    private bool _recycle;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_endPos.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Finish")
        {
            Recycle();
        }
    }
    private void OnEnable()
    {

        if (_recycle==true)
        {
            Recycle();
        }
        else
        {
            return;
        }
     //   Invoke("Recycle", 25);
    }

    private void Recycle()
    {
        _recycle = false;
        this.gameObject.transform.position = _startingPos.position;

        this.gameObject.SetActive(false);
        


    }
}
