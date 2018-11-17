using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBarrier : MonoBehaviour {

    public Material RedFail;
    public GameObject Barrier;


    private void Start()
    {
        Barrier = transform.GetChild(0).gameObject;
    }



    private void OnTriggerEnter(Collider b)
    {
        if (b.gameObject.CompareTag("nonPlayer"))
        {
            Barrier.GetComponent<Renderer>().material = RedFail;
            Debug.Log("gg");
        }
    }
}
