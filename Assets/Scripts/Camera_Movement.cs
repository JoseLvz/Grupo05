using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 DesiredPosition = new Vector3(0,0,target.transform.position.z) + offset;
        Vector3 Smooth = Vector3.Lerp(transform.position, DesiredPosition,smoothSpeed);
        transform.position = Smooth;

        Rotate();
    }

    public void Rotate()
    {
        if (Input.GetKey(KeyCode.Q)){
            transform.Rotate(0, 0, 80 * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.E)){
            transform.Rotate(0, 0, -80 * Time.deltaTime);
        }
    }
}
