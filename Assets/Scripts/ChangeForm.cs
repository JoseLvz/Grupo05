using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : MonoBehaviour {
    int selectedCharacter = 1;
    string characterName;
    public GameObject Nave, Nave2, Nave3;


    void Start()
    {

        Nave.gameObject.SetActive(true);
        Nave2.gameObject.SetActive(false);
        Nave3.gameObject.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedCharacter < 4)
                selectedCharacter++;


        }
        SwitchShip();
    }

    public void SwitchShip()
    {
        switch (selectedCharacter)
        {
            case 1:
                ;
                Nave.gameObject.SetActive(false);
                Nave2.gameObject.SetActive(true);
                break;
            case 2:
                ;
                Nave3.gameObject.SetActive(true);
                Nave2.gameObject.SetActive(false);
                break;
            case 3:
                ;
                Nave.gameObject.SetActive(true);
                Nave3.gameObject.SetActive(false);
                break;
            default:
                selectedCharacter = 1;
                Nave.gameObject.SetActive(false);
                Nave2.gameObject.SetActive(true);
                break;
        }

    }
}
