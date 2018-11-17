using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_VFX_Manager : Nave {
    public GameObject Spark1, Spark2;
    public GameObject S_Rocket1;

    void Start()
    {
        S_Rocket1.gameObject.SetActive(true);
        Spark1.gameObject.SetActive(false);
        Spark2.gameObject.SetActive(false);
    }

    void Update()
    {

        switch (life)
        {
            case 3:
                ;
                S_Rocket1.gameObject.SetActive(true);
                break;
            case 2:
                ;
                S_Rocket1.gameObject.SetActive(true);
                Spark1.gameObject.SetActive(true);
                Spark2.gameObject.SetActive(false);
                break;
            case 1:
                ;
                S_Rocket1.gameObject.SetActive(true);
                Spark1.gameObject.SetActive(true);
                Spark2.gameObject.SetActive(true);
                break;
            case 0:
                ;
                S_Rocket1.gameObject.SetActive(false);
                Spark1.gameObject.SetActive(true);
                Spark2.gameObject.SetActive(true);
                break;
            default:
                S_Rocket1.gameObject.SetActive(true);
                break;
        }
    }
}
