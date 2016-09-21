using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RailSectionSwitchLeft : RailSection {

    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    private const float R = 25.0f;

    public override List<Vector3> GetBackbonePoints()
    {
        List<Vector3> p = new List<Vector3>();

        Vector3 center = transform.position + transform.TransformVector(Vector3.left) * R;
        Vector3 dir = transform.position - center;

        dir = Quaternion.Euler(0, 22.5f, 0) * dir;
        p.Add(center + dir);

        for (int a = 0; a < 8; a++)
        {
            dir = Quaternion.Euler(0, -45f/8f, 0) * dir;
            p.Add(center + dir);
        }


        return p;
    }}
