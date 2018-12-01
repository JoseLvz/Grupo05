using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave_Vista : Nave_Modelo {


    public Nave_Modelo modelo;



    void Movement(float H_Movement, float V_Movement, float speed, float Zspeed, Transform Nave)
    {
        Nave.Translate(H_Movement * Time.deltaTime * speed, V_Movement * Time.deltaTime * speed, Zspeed * Time.deltaTime);
    }

    public static void Rotate(Vector3 _randomRotation, float _Rotation, Transform _Nave)
    {
        _randomRotation.x = Random.Range(-_Rotation, _Rotation);
        _randomRotation.y = Random.Range(-_Rotation, _Rotation);
        _randomRotation.z = Random.Range(-_Rotation, _Rotation);

        _Nave.Rotate(_randomRotation * Time.deltaTime);
    }

    public static void Limits(Rigidbody _Rig, float _Xmin, float _Xmax, float _Ymin, float _Ymax, float _Zmin, float _Zmax)
    {
        _Rig.position = new Vector3(Mathf.Clamp(_Rig.position.x, _Xmin, _Xmax), Mathf.Clamp(_Rig.position.y, _Ymin, _Ymax), Mathf.Clamp(_Rig.position.z, _Zmin, _Zmax));
    }

    void Acceleration(float _Zspeed)
    {
        _Zspeed++;
    }

    //---------------------------------------------------

    public void OnNormal()
    {
        Movement(modelo.H_movement, modelo.V_Movement, modelo.speed, modelo.Zspeed, modelo.transform);
        Acceleration(modelo.Zspeed);
        Limits(modelo.Rig, modelo.Xmin, modelo.Xmax, modelo.Ymin, modelo.Ymax, modelo.Zmin, modelo.Zmax);
    }

    public void OnDead(Rigidbody Rig )
    {
        Rotate(modelo.randomRotation, modelo.zRotation , modelo.transform);
        modelo.isDead = true;
        Rig.constraints = RigidbodyConstraints.None;
        Rig.AddForce(0, 0, 0.0005f, ForceMode.Impulse);
    }

    public void End( Rigidbody Rig)
    {
        Rig.AddForce(0, 0, 1, ForceMode.Impulse);
    }
}
