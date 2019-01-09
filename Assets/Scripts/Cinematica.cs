using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematica : MonoBehaviour {

    public GameObject cam1, cam2, cam3,cam4,cam5,cam51,cam52,cam6;

	void Start () {

        StartCoroutine(cinematica());
	}
	

    IEnumerator cinematica()
    {
        cam1.SetActive(true);
        yield return new WaitForSeconds(8f);
        cam2.SetActive(true);
        cam1.SetActive(false);
        yield return new WaitForSeconds(6f);
        cam3.SetActive(true);
        cam2.SetActive(false);
        yield return new WaitForSeconds(5f);
        cam3.SetActive(false);
        cam4.SetActive(true);
        yield return new WaitForSeconds(6f);
        cam4.SetActive(false);
        cam5.SetActive(true);
        yield return new WaitForSeconds(3f);
        cam5.SetActive(false);
        cam51.SetActive(true);
        yield return new WaitForSeconds(3f);
        cam51.SetActive(false);
        cam52.SetActive(true);
        yield return new WaitForSeconds(3f);
        cam52.SetActive(false);
        cam6.SetActive(true);
    }   
}
