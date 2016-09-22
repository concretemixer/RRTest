using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RailSectionSwitch : RailSection
{
    public RailSection railSectionThird;
    public bool switchedToSide = false;

    protected void IndicateSwitch()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == false || !lineRenderer.enabled)
            return;

        List<Vector3> backbone = GetBackbonePoints(this);

        lineRenderer.SetVertexCount(backbone.Count);
        lineRenderer.SetPositions(backbone.ToArray());
    }

    public void SetSwitched(bool value)
    {
        switchedToSide = value;
        IndicateSwitch();
    }

}
