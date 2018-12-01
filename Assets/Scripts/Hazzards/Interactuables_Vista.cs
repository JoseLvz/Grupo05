using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuables_Vista : MonoBehaviour {

    public static void RotateinAllDirection(Transform transform , Vector3 randomRotation)
    {
        transform.Rotate(randomRotation * Time.deltaTime);
    }

    public static void RotateinZ(Transform transform , int SpeedRotation)
    {
        transform.Rotate(0, 10 * SpeedRotation * Time.deltaTime, 0);
    }

    public static void PowerUpsEffect(Nave nave , GameObject powerup, int AddLife)
    {
        nave.life += AddLife;
        Destroy(powerup.gameObject);
    }

 
}
