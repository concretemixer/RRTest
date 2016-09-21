using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour {

    public Locomotion[] train;
	// Use this for initialization
	void Start () {
	
	}
	
    float v = 0;
    float a = 0;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            a = -5;
        }

        if (Mathf.Abs(v)<30)
            v += a * Time.deltaTime;

       
        if (v!=0)
            Move(v*Time.deltaTime);	
	}

    public void Move(float distance)
    {
        foreach (var car in train)
        {
            car.Move(distance);
        }
    }
}
