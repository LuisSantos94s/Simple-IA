using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour {

    public Transform[] WayPoints;
    public Color colorState = Color.green;

    private StatesMachine statesMachine;
    private ControladorNavMesh controladorNavMesh;
    private VisionControl visionControl;

    private int nextWayPoint;

	// Use this for initialization
	void Awake ()
    {
        visionControl = GetComponent<VisionControl>();
        statesMachine = GetComponent<StatesMachine>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit hit;
        if(visionControl.SeePlayer(out hit))
        {
            controladorNavMesh.followObjective = hit.transform;
            statesMachine.ActiveState(statesMachine.PatrolState);
            return;
        }

        if (controladorNavMesh.IArrived())
        {
            nextWayPoint = (nextWayPoint + 1) % WayPoints.Length;
            UpdateWayPointDestiny();
        }
	}

    void OnEnable()
    {
        statesMachine.MeshRendererIndicador.material.color = colorState;
        UpdateWayPointDestiny();   
    }

    void UpdateWayPointDestiny()
    {
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(WayPoints[nextWayPoint].position);   
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && enabled)
        {
            statesMachine.ActiveState(statesMachine.AlertState);
        }
    }
}
