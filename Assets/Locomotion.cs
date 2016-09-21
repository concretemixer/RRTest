using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Locomotion : MonoBehaviour {
       
    public Railroad railroad;
    public GameObject bogieFwd;
    public GameObject bogieBwd;

    private Vector3 toBogieFwd;
    private Vector3 toBogieBwd;

    private float distanceBetweenBogies;

	// Use this for initialization
	void Start () {
        toBogieBwd = transform.position - bogieBwd.transform.position;
        toBogieFwd = transform.position - bogieFwd.transform.position;

        distanceBetweenBogies = (bogieFwd.transform.position - bogieBwd.transform.position).magnitude;        
	}
	
    private float v = -1;
	// Update is called once per frame
	void Update () {

	}

    private void MoveBogie(List<Vector3> backbone, Transform t, float distance, out Vector3 pos, out Quaternion rot)
    {
        Vector3 fwd = t.TransformVector(Vector3.forward * distance);

        int closest = -1;
        float d = float.MaxValue;
        for (int a = 0; a < backbone.Count - 1; a++)
        {
            Vector3 v = (backbone[a] + backbone[a + 1]) / 2;
            float _d = Vector3.Distance(v, t.position + fwd);
            if (_d < d)
            {
                closest = a;
                d = _d;
            }
        }

        {
            Vector3 current = backbone[closest + 1] - backbone[closest];
            Vector3 v = (t.position+fwd) - backbone[closest];
            Vector3 pnt = backbone[closest] + Vector3.Project(v, current);

            pos = pnt;
            if (Mathf.Sign(distance)>0)
                rot= Quaternion.LookRotation(current, Vector3.up);
            else
                rot= Quaternion.LookRotation(-current, Vector3.up);
        }        
    }


    public void Move(float distance)
    {
        if (distance == 0)
            return;

        RailSection rails = GetRailSectionUnder(transform);

        List<Vector3> backbone = rails.GetBackbonePoints();

        if (rails.railSectionPrev!=null)
            backbone.AddRange(rails.railSectionPrev.GetBackbonePoints());
        if (rails.railSectionNext!=null)
            backbone.AddRange(rails.railSectionNext.GetBackbonePoints());

        Vector3 fwd = transform.TransformVector(Vector3.forward * distance);

        backbone.Sort(delegate(Vector3 v1, Vector3 v2)
        {
            return Vector3.Dot(v1, fwd).CompareTo(Vector3.Dot(v2, fwd));
        });

       // GetComponent<LineRenderer>().SetVertexCount(backbone.Count);
        //GetComponent<LineRenderer>().SetPositions(backbone.ToArray());

        Vector3 bogieFwdMoved,bogieBwdMoved;
        Quaternion bogieFwdRotated, bogieBwdRotated;
        MoveBogie(backbone, bogieFwd.transform, distance,out bogieFwdMoved, out bogieFwdRotated);
        MoveBogie(backbone, bogieBwd.transform, distance,out bogieBwdMoved, out bogieBwdRotated);

        transform.position = (bogieFwdMoved +bogieBwdMoved)/2 + new Vector3(0,-0.072f,0);
        transform.rotation = Quaternion.LookRotation(bogieFwdMoved-bogieBwdMoved,Vector3.up);

        bogieBwd.transform.rotation = bogieBwdRotated;
        bogieFwd.transform.rotation = bogieFwdRotated;
    }

    private RailSection GetRailSectionUnder(Transform transform)
    {
        RailSection result = null;

        float d = float.MaxValue;
        foreach (var rail in railroad.GetComponentsInChildren<RailSection>())
        {
            float _d = (rail.transform.position - transform.position).sqrMagnitude;
            if (_d < d)
            {
                d = _d;
                result = rail;
            }
        }

        return result;
    }

}
