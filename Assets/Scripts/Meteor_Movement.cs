using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Movement : MonoBehaviour {

    Rigidbody mRig;

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<Rigidbody>();
        mRig = GetComponent<Rigidbody>();
        mRig.useGravity = false;
        mRig.angularDrag = 0;
        mRig.angularVelocity = Random.insideUnitSphere * 1;
    }
	
	// Update is called once per frame
	void Update () {

    }

}
