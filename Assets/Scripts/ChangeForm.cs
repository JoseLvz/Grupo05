using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : MonoBehaviour {
    int selectedCharacter = 1;
    string characterName;
    public GameObject Nave, Nave2, Nave3;
    public MeshCollider C_Collider;
    public SphereCollider S_remplazo;
    public GameObject T_remplazo;

    /*public ParticleSystem cubo;
    public ParticleSystem triangulo;
    public ParticleSystem esfera;*/
    //public Transform particle;


    void Start()
    {

        Nave.gameObject.SetActive(true);
        Nave2.gameObject.SetActive(false);
        Nave3.gameObject.SetActive(false);
        C_Collider.gameObject.SetActive(false);
        S_remplazo.gameObject.SetActive(true);
        T_remplazo.gameObject.SetActive(false);

        //particle.GetComponent<ParticleSystem>().enableEmission = true;

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
                S_remplazo.gameObject.SetActive(true);

                //cubo.Emit(1);
                break;
            case 2:
                ;
                Nave3.gameObject.SetActive(true);
                Nave2.gameObject.SetActive(false);
                T_remplazo.gameObject.SetActive(true);
                S_remplazo.gameObject.SetActive(false);
                break;
            case 3:
                ;
                Nave.gameObject.SetActive(true);
                Nave3.gameObject.SetActive(false);
                C_Collider.gameObject.SetActive(true);
                S_remplazo.gameObject.SetActive(false);
                T_remplazo.gameObject.SetActive(false);
                break;
            default:
                selectedCharacter = 1;
                Nave.gameObject.SetActive(false);
                Nave2.gameObject.SetActive(true);
                S_remplazo.gameObject.SetActive(true);
                C_Collider.gameObject.SetActive(false);
                break;
        }

    }

    /*IEnumerator stop()
    {
        yield return new WaitForSeconds(1f);
        particleEmitter.GetComponent<ParticleSystem>().enableEmission = false;
    }*/
}
