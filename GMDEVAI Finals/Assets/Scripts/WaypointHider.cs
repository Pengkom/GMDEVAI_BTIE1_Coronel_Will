using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointHider : MonoBehaviour
{
    public bool hideWaypoints;
    
    void Start()
    {
        if (hideWaypoints)
        {
            var renderer = this.GetComponent<MeshRenderer>();
            renderer.enabled = false;
            Destroy(this);
        }
    }
}
