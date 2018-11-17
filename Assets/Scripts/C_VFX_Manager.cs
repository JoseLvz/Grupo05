using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_VFX_Manager : MonoBehaviour {

    public GameObject Spark1, Spark2, Spark3;
    public GameObject MainRocket,R1,R2,R3;
    public Nave nave;

	void Start () {
        R1.gameObject.SetActive(true);
        R2.gameObject.SetActive(true);
        R3.gameObject.SetActive(true);
        Spark1.gameObject.SetActive(false);
        Spark2.gameObject.SetActive(false);
        Spark3.gameObject.SetActive(false);
    }
	
	void Update () {
		
        switch (nave.life)
        {
            case 3:
                ;
                MainRocket.gameObject.SetActive(true);
                R1.gameObject.SetActive(true);
                R2.gameObject.SetActive(true);
                R3.gameObject.SetActive(true);

                Spark1.gameObject.SetActive(false);
                Spark2.gameObject.SetActive(false);
                Spark3.gameObject.SetActive(false);

                break;
            case 2:
                ;
                MainRocket.gameObject.SetActive(true);
                R1.gameObject.SetActive(false);
                R2.gameObject.SetActive(true);
                R3.gameObject.SetActive(true);

                Spark1.gameObject.SetActive(true);
                Spark2.gameObject.SetActive(false);
                Spark3.gameObject.SetActive(false);
                break;
            case 1:
                ;
                MainRocket.gameObject.SetActive(true);
                R1.gameObject.SetActive(false);
                R2.gameObject.SetActive(false);
                R3.gameObject.SetActive(false);

                Spark1.gameObject.SetActive(true);
                Spark2.gameObject.SetActive(true);
                Spark3.gameObject.SetActive(true);
                break;
            case 0:
                ;
                MainRocket.gameObject.SetActive(false);
                R1.gameObject.SetActive(false);
                R2.gameObject.SetActive(false);
                R3.gameObject.SetActive(false);

                Spark1.gameObject.SetActive(true);
                Spark2.gameObject.SetActive(true);
                Spark3.gameObject.SetActive(true);
                break;
            default:
                ;
                MainRocket.gameObject.SetActive(true);
                R1.gameObject.SetActive(true);
                R2.gameObject.SetActive(true);
                R3.gameObject.SetActive(true);

                Spark1.gameObject.SetActive(false);
                Spark2.gameObject.SetActive(false);
                Spark3.gameObject.SetActive(false);
                break;
        }
    }
}
