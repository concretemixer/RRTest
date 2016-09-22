using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RailSectionSwitchRight : RailSectionSwitch
{

    void Start () {
        IndicateSwitch();
    }

    // Update is called once per frame
    void Update () {

    }

    private const float R = 25.5f;

    public override List<Vector3> GetBackbonePoints(RailSection section)
    {
        List<Vector3> p = new List<Vector3>();

        Vector3 center = transform.position + transform.TransformVector(Vector3.left) * R;
        Vector3 dir = transform.position - center;

        bool returnSwitched = false;

        if (section.gameObject.GetInstanceID() == this.gameObject.GetInstanceID())
        {
            returnSwitched = switchedToSide;
        }
        if (section.gameObject.GetInstanceID() == railSectionThird.gameObject.GetInstanceID())
        {
            returnSwitched = true;
            SetSwitched(true);
        }
        if (section.gameObject.GetInstanceID() == railSectionPrev.gameObject.GetInstanceID())
        {
            returnSwitched = switchedToSide;
        }
        if (section.gameObject.GetInstanceID() == railSectionNext.gameObject.GetInstanceID())
        {
            returnSwitched = false;
            SetSwitched(false);
        }


        if (returnSwitched)
        {
            dir = Quaternion.Euler(0, -22.5f, 0) * dir;
            p.Add(center + dir);

            for (int a = 0; a < 8; a++)
            {
                dir = Quaternion.Euler(0, 45f / 8f, 0) * dir;
                p.Add(center + dir);
            }
        }
        else
        {
            dir = Quaternion.Euler(0, -22.5f, 0) * dir;
            Vector3 point = center + dir;

            dir = Quaternion.Euler(0, 90f, 0) * dir;
            dir.Normalize();


            p.Add(point + dir * 2);            
            p.Add(point + dir * 18);
        }

        return p;
    }

    public override List<RailSection> GetAdjacentSections()
    {
        var result = new List<RailSection>();
        if (switchedToSide)
        {
            if (railSectionThird != null)
                result.Add(railSectionThird);
        }
        else
        {
            if (railSectionNext != null)
                result.Add(railSectionNext);
        }

        if (railSectionPrev != null)
            result.Add(railSectionPrev);

        return result;
    }


}
