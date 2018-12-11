using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour {

    public int SpeedRotation;
    [Range(-1,1)]
    public int Direction;
    public int damageDeal;


    public Nave nave;

	void Start () {

        nave = FindObjectOfType<Nave>();
    }
	
	// Update is called once per frame
	void Update () {

        RotationInZ();
	}

    void RotationInZ()
    {
        transform.Rotate(0, 10 * SpeedRotation * Direction * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            nave.life = nave.life - damageDeal;
            FindObjectOfType<AudioManager>().Play("Impact_Meteor");
        }
    }
}
