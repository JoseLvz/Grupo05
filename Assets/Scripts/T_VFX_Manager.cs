using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_VFX_Manager : MonoBehaviour {

    public GameObject S_Top, S_Left, S_Right;
    public GameObject Top, Left, Right;
    public Nave nave;

    void Start()
    {
        Top.gameObject.SetActive(true);
        Left.gameObject.SetActive(true);
        Right.gameObject.SetActive(true);
        S_Top.gameObject.SetActive(false);
        S_Left.gameObject.SetActive(false);
        S_Right.gameObject.SetActive(false);
    }

    void Update()
    {

        switch (nave.life)
        {
            case 3:
                ;
                Top.gameObject.SetActive(true);
                Left.gameObject.SetActive(true);
                Right.gameObject.SetActive(true);

                S_Top.gameObject.SetActive(false);
                S_Left.gameObject.SetActive(false);
                S_Right.gameObject.SetActive(false);

                break;
            case 2:
                ;
                Top.gameObject.SetActive(true);
                Left.gameObject.SetActive(false);
                Right.gameObject.SetActive(true);

                S_Top.gameObject.SetActive(false);
                S_Left.gameObject.SetActive(true);
                S_Right.gameObject.SetActive(false);
                break;
            case 1:
                ;
                Top.gameObject.SetActive(true);
                Left.gameObject.SetActive(false);
                Right.gameObject.SetActive(false);

                S_Top.gameObject.SetActive(false);
                S_Left.gameObject.SetActive(true);
                S_Right.gameObject.SetActive(true);
                break;
            case 0:
                ;
                Top.gameObject.SetActive(false);
                Left.gameObject.SetActive(false);
                Right.gameObject.SetActive(false);

                S_Top.gameObject.SetActive(true);
                S_Left.gameObject.SetActive(true);
                S_Right.gameObject.SetActive(true);
                break;
            default:
                ;
                Top.gameObject.SetActive(true);
                Left.gameObject.SetActive(true);
                Right.gameObject.SetActive(true);

                S_Top.gameObject.SetActive(false);
                S_Left.gameObject.SetActive(false);
                S_Right.gameObject.SetActive(false);
                break;
        }
    }
}
