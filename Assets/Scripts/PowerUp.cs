using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public Nave nave;
    Rigidbody pRig;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        pRig = GetComponent<Rigidbody>();
        pRig.useGravity = false;
        pRig.angularDrag = 0;
        pRig.angularVelocity = Random.insideUnitSphere * 0.5f;

    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("nonPlayer"))
        {
            nave.life++;
            Destroy(this.gameObject);
        }
        
    }
}
