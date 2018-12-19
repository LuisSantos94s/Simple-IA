using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesMachine : MonoBehaviour {

    public MonoBehaviour PatrolState;
    public MonoBehaviour AlertState;
    public MonoBehaviour FollowState;
    public MonoBehaviour StartState;

    public MeshRenderer MeshRendererIndicador;

    private MonoBehaviour ActualState;

    void Start () {
        ActiveState (StartState);
	}
	
    public void ActiveState (MonoBehaviour newState)
    {
        if (ActualState != null) ActualState.enabled = false;
        ActualState = newState;
        ActualState.enabled = true;
    }
}
