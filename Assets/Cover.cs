using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cover : MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GameObject.Find("Monster_93").GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayOrigin = new Ray(transform.position, transform.right);
        RaycastHit hitInfo;
        Debug.DrawRay(rayOrigin.origin, rayOrigin.direction * 10);

        if (Physics.Raycast(rayOrigin,out hitInfo))
        {
       //     Debug.Log("hit the enemy");
        }

    }
}
