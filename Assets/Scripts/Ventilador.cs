using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour {

    public int SpeedRotation;

	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

        RotationInZ();
	}

    void RotationInZ()
    {
        transform.Rotate(0, 10 * SpeedRotation * Time.deltaTime, 0);
    }
}
