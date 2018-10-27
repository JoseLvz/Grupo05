using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {

    public float speed = 2f;
    public float Zspeed;
    float life;
    float H_movement;
    float V_Movement;
    public float Xmin, Xmax, Ymin, Ymax , Zmin , Zmax;
    public float zAngle = 90;
    public float RollSpeed;

    private Rigidbody Rig;

    public bool isDead;

    void Start() {
        isDead = false;
        Rig = GetComponent<Rigidbody>();
        InvokeRepeating("Acceleration",1,6);
    }

    void Update() {

        H_movement = Input.GetAxis("Horizontal");
        V_Movement = Input.GetAxis("Vertical");

        if(isDead == false)
        {
            Movement();
            Rotate();
        }
        //limits();

        //Roll();
    }

    public void Movement() {
        transform.Translate(H_movement*Time.deltaTime*speed,V_Movement*Time.deltaTime*speed,Zspeed*Time.deltaTime);
        //Rig.velocity = M * speed * Time.deltaTime;
        //Rig.position += new Vector3(H_movement*Time.deltaTime*speed,V_Movement*Time.deltaTime*speed,Zspeed*Time.deltaTime);
    }

    public void Roll(){
        Rig.rotation = Quaternion.Euler(Rig.velocity.y*-RollSpeed, 0, Rig.velocity.x * -RollSpeed);
    }

    public void limits(){
        Rig.position = new Vector3(Mathf.Clamp(Rig.position.x, Xmin, Xmax), Mathf.Clamp(Rig.position.y, Ymin, Ymax), 0);
    }

    public void Acceleration(){
        if (isDead == false){
            Zspeed++;
        }
    }
    public void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag("Hazzard")){
            isDead=true;
            Vector3 RotationVel = new Vector3(Random.Range(-1,1), Random.Range(-1, 1),0);
            Rig.angularVelocity = RotationVel;

        }
    }

    public void Rotate(){
        if (Input.GetKey(KeyCode.Q)){
            transform.Rotate(0, 0, 80 * Time.deltaTime);
            //RotatePoint.transform.Rotate(Vector3.right * Time.deltaTime, zAngle, Space.Self);
            //RotatePoint.transform.Rotate(0, 0,zAngle, Space.Self);
        }
        if (Input.GetKey(KeyCode.E)){
            //RotatePoint.transform.Rotate(0, 0,-zAngle, Space.Self);
            //RotatePoint.transform.Rotate(Vector3.left * Time.deltaTime, zAngle, Space.Self);
            transform.Rotate(0, 0, -80 * Time.deltaTime);
        }
    }
}

