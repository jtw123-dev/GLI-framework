using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITestScript : MonoBehaviour
{
    [SerializeField] private Transform _transformA;
    [SerializeField] private Transform _transformB;
    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_transformB.position);
    }
}
