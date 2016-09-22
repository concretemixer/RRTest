using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RailSection : MonoBehaviour {

    public RailSection railSectionPrev;
    public RailSection railSectionNext;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual List<Vector3> GetBackbonePoints(RailSection section)
    {
        return new List<Vector3>();
    }

    public virtual List<RailSection> GetAdjacentSections()
    {
        var result = new List<RailSection>();
        if (railSectionNext != null)
            result.Add(railSectionNext);
        if (railSectionPrev != null)
            result.Add(railSectionPrev);
        return result;
    }

}
