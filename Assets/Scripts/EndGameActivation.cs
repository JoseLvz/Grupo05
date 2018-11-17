using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameActivation : MonoBehaviour {

    public Nave nave;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("nonPlayer"))
        {
            nave.endGame= true;
        }
    }
}
