using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Movement : MonoBehaviour {

    float Rotation = 50f;

    Transform thistransform;
    Vector3 randomRotation;

    void Awake()
    {
        thistransform = transform;
    }

    void Start () {

        randomRotation.x = Random.Range(-Rotation, Rotation);
        randomRotation.y = Random.Range(-Rotation, Rotation);
        randomRotation.z = Random.Range(-Rotation, Rotation);

    }
	
	void Update () {

        thistransform.Rotate(randomRotation * Time.deltaTime);
    }

}
