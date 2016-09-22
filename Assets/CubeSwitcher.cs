using UnityEngine;
using System.Collections;

public class CubeSwitcher : MonoBehaviour {

    public RailSectionSwitch section;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
            if (Input.GetMouseButtonDown(0) && section!=null)
            {                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    //Debug.Log(hit.transform.gameObject.name);
                    if (hit.transform.gameObject.GetInstanceID() == gameObject.GetInstanceID())
                    {
                        section.SetSwitched(!section.switchedToSide);
                    }
                }
            }
	
	}
}
