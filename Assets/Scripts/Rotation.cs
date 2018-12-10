using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
    }

    public void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 0, 90 * Time.deltaTime);
            //RotatePoint.transform.Rotate(Vector3.right * Time.deltaTime, zAngle, Space.Self);
            //RotatePoint.transform.Rotate(0, 0,zAngle, Space.Self);
        }
        if (Input.GetKey(KeyCode.E))
        {
            //RotatePoint.transform.Rotate(0, 0,-zAngle, Space.Self);
            //RotatePoint.transform.Rotate(Vector3.left * Time.deltaTime, zAngle, Space.Self);
            transform.Rotate(0, 0, -90 * Time.deltaTime);
        }
    }
}
