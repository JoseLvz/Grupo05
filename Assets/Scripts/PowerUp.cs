using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    float Rotation = 20f;

    public Nave nave;
    Vector3 randomRotation;

    void Start()
    {

        randomRotation.x = Random.Range(-Rotation, Rotation);
        randomRotation.y = Random.Range(-Rotation, Rotation);
        randomRotation.z = Random.Range(-Rotation, Rotation);

    }

    void Update()
    {

        transform.Rotate(randomRotation * Time.deltaTime);
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
