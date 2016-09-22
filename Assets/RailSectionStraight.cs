using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RailSectionStraight : RailSection {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override List<Vector3> GetBackbonePoints(RailSection section)
    {
        List<Vector3> p = new List<Vector3>();
        p.Add(transform.position + transform.TransformVector(Vector3.forward) * 9);
        p.Add(transform.position + transform.TransformVector(Vector3.back) * 9);

        return p;
    }

    
}
