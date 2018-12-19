using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorNavMesh : MonoBehaviour {

    [HideInInspector]
    public Transform followObjective;

    private NavMeshAgent navMeshAgent;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void ActualizarPuntoDestinoNavMeshAgent(Vector3 puntoDestino)
    {
        navMeshAgent.destination = puntoDestino;
        navMeshAgent.isStopped = false;
    }

    public void ActualizarPuntoDestinoNavMeshAgent()
    {
        ActualizarPuntoDestinoNavMeshAgent(followObjective.position);
    }

    public void DetenerNavMeshAgent ()
    {
        navMeshAgent.isStopped = true;
    }

    public bool IArrived()
    {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }
}
