using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : MonoBehaviour {

    public float rotateFindSpeed = 120f;
    public float durationFinding = 4f;
    public Color ColorState = Color.yellow;

    private StatesMachine statesMachine;
    private ControladorNavMesh controladorNavMesh;
    private VisionControl visionControl;
    private float timeFinding;

    void Awake()
    {
        visionControl = GetComponent<VisionControl>();
        statesMachine = GetComponent<StatesMachine>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
    }

    void OnEnable()
    {
        statesMachine.MeshRendererIndicador.material.color = ColorState;
        controladorNavMesh.DetenerNavMeshAgent();
        timeFinding = 0f;
    }

    void Update ()
    {
        RaycastHit hit;
        if (visionControl.SeePlayer(out hit))
        {
            controladorNavMesh.followObjective = hit.transform;
            statesMachine.ActiveState(statesMachine.FollowState);
            return;
        }
        transform.Rotate(0f, rotateFindSpeed * Time.deltaTime, 0f);
        timeFinding += Time.deltaTime;
        if(timeFinding >= durationFinding)
        {
            statesMachine.ActiveState(statesMachine.PatrolState);
            return;
        }
	}
}
