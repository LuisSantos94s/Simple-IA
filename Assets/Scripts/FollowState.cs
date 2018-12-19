using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : MonoBehaviour {

    public Color ColorState = Color.red;

    private StatesMachine stateMachine;
    private ControladorNavMesh controladorNavMesh;
    private VisionControl visionControl;


    void Awake()
    {
        stateMachine = GetComponent<StatesMachine>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        visionControl = GetComponent<VisionControl>();

    }

    void OnEnable()
    {
        stateMachine.MeshRendererIndicador.material.color = ColorState;   
    }

    void Update ()
    {
        RaycastHit hit;
        if(!visionControl.SeePlayer(out hit, true))
        {
            stateMachine.ActiveState(stateMachine.AlertState);
            return;
        }
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
	}
}
