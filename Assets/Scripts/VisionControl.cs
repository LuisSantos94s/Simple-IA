using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionControl : MonoBehaviour {

    public Transform Eyes;
    public float visionRange = 20f;
    public Vector3 offset = new Vector3(0f, 0.75f, 0f);

    private ControladorNavMesh controladorNavMesh;
    
    void Awake()
    {
        controladorNavMesh = GetComponent<ControladorNavMesh>();
    }

    public bool SeePlayer(out RaycastHit hit, bool playerDirection = false)
    {
        Vector3 vectorDirection;
        if (playerDirection)
        {
            vectorDirection = (controladorNavMesh.followObjective.position + offset) - Eyes.position;
        }
        else
        {
            vectorDirection = Eyes.forward;
        }

        return Physics.Raycast(Eyes.position, vectorDirection, out hit, visionRange) && hit.collider.CompareTag("Player"); 
    }
}
