using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour {

    public int SpeedRotation;
    [Range(-1, 1)]
    public int Direction;
    public int damageDeal;

    public GameObject aspas;


    Camera_Movement cam;
    Nave nave;

    void Start()
    {
        cam = FindObjectOfType<Camera_Movement>();
        nave = FindObjectOfType<Nave>();

    }

    void Update()
    {

        RotationInZ();
    }

    void RotationInZ()
    {
        aspas.transform.Rotate(0, 0, SpeedRotation * Direction * Time.deltaTime);
    }


    public void pullTrigger(Collider cc)
    {
        if (cc.gameObject.CompareTag("nonPlayer"))
        {
            Debug.Log("ggwp");
            cam.shake = true;
            nave.life = nave.life - damageDeal;
            nave.TakeColliders();
            FindObjectOfType<AudioManager>().Play("Impact_Barrier");
        }
    }

}
