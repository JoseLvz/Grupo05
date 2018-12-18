using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematica : MonoBehaviour {

    public GameObject cam1, cam2, cam3;

	void Start () {

        StartCoroutine(cinematica());
	}
	

    IEnumerator cinematica()
    {
        cam1.SetActive(true);
        yield return new WaitForSeconds(6f);
        cam2.SetActive(true);
        cam1.SetActive(false);
        yield return new WaitForSeconds(6f);
        cam3.SetActive(true);
        cam2.SetActive(false);

    }   
}
