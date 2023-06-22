using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshPlus;

public class NavMeshTarget : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent agent;

    void Start()	
    {
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = true;
		agent.updateUpAxis = false;
        SetDestination (target);
	}

    void SetDestination(Transform target)
    {
        var agentDrift = 0.0001f; // minimal
        var driftPos = target.transform.position + (Vector3)(agentDrift * Random.insideUnitCircle);
        agent.SetDestination(driftPos);
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(180, 0, 0);
    }
}
