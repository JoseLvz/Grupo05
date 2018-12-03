using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrellasVelocidad : MonoBehaviour {

	public Transform target;

	public Vector3 DistancePos;


	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void Update () {

		Vector3 Pos = target.position + DistancePos;
		transform.position = Pos;
	}


}
