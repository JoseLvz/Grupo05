using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public Transform target;
    public Nave nave;
    Vector3 randomRotation;

    void Start()
    {


        nave = FindObjectOfType<Nave>();
        target = GameObject.FindWithTag("Player").transform;


    }

    void Update()
    {   
        transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("nonPlayer"))
        {
            nave.life++;
            FindObjectOfType<AudioManager>().Play("Heal");
            Destroy(this.gameObject);
        }        
    }
}
