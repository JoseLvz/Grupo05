using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {

    float speed = 3.0f;
    public float Zspeed;
    public int life=3;
    float H_movement;
    float V_Movement;
    public float Xmin, Xmax, Ymin, Ymax , Zmin , Zmax;
    public float zAngle = 90;


    

    Rigidbody Rig;
    //public CameraShake C_Shake;
    /*public Transform Player;
    GameObject HZ;*/

    public bool isDead;
    public bool endGame;

    public Transform allColliders;

    public Camera_Movement cam;
    Vector3 randomRotation;

    bool isPause;
    float RotationSpeed = 50f;


    void Start() {

        FindObjectOfType<AudioManager>().Play("Motor");

        isDead = false;
        endGame = false;
        Rig = GetComponent<Rigidbody>();
        InvokeRepeating("Acceleration",1,6);
        Physics.IgnoreLayerCollision(9, 10);

        H_movement = Input.GetAxis("Horizontal");
        V_Movement = Input.GetAxis("Vertical");


        randomRotation.x = Random.Range(-RotationSpeed, RotationSpeed);
        randomRotation.y = Random.Range(-RotationSpeed, RotationSpeed);
        randomRotation.z = Random.Range(-RotationSpeed, RotationSpeed);


        /*Physics.IgnoreCollision(Player.GetComponent<Collider>(),HZ.GetComponent<Collider>());
        HZ = GameObject.FindGameObjectWithTag("Hazzard");*/
    }

    void Update() {

        //H_movement = (isPause)? 0: Input.GetAxis("Horizontal");
        H_movement = Input.GetAxis("Horizontal");
        V_Movement = Input.GetAxis("Vertical");



        if (life > 0)
        {
            Movement();
            Rotate();
            Limits();
        }
        else
        {
            DeadState();
        }

        EndGame();
    }

    public void Movement() {
        transform.Translate(H_movement*Time.deltaTime*speed,V_Movement*Time.deltaTime*speed,Zspeed*Time.deltaTime);
        //Rig.velocity = M * speed * Time.deltaTime;
        //Rig.position += new Vector3(H_movement*Time.deltaTime*speed,V_Movement*Time.deltaTime*speed,Zspeed*Time.deltaTime);
    }

    public void Limits(){
        Rig.position = new Vector3(Mathf.Clamp(Rig.position.x, Xmin, Xmax), Mathf.Clamp(Rig.position.y, Ymin, Ymax), Mathf.Clamp(Rig.position.z, Zmin, Zmax));
    }

    public void Acceleration(){
        if (isDead == false){
            Zspeed++;
        }
    }
    void DeadState(){
        isDead = true;
        Rig.constraints = RigidbodyConstraints.None;
        transform.Rotate(randomRotation * Time.deltaTime);

        Rig.AddForce(0, 0, 0.0005f, ForceMode.Impulse);
        allColliders.gameObject.SetActive(false);

        FindObjectOfType<AudioManager>().StopVFX("Motor");

    }
    void EndGame()
    {
        if (endGame == true)
        {
            Rig.AddForce(0, 0, 1, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Hazzard")){
            life -= 1;
            cam.shake = true;
            BackColliders();
        }
        StartCoroutine(BackColliders());
    }
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Barrier"))
        {
            life -= 1;
            allColliders.gameObject.SetActive(false);
            cam.shake = true;

        }
        StartCoroutine(BackColliders());
    }

    IEnumerator BackColliders()
    {
        yield return new WaitForSeconds(0.7f);
        allColliders.gameObject.SetActive(true);

    }



    public void Rotate(){
        if (Input.GetKey(KeyCode.Q)){
            transform.Rotate(0, 0, 90 * Time.deltaTime);
            //RotatePoint.transform.Rotate(Vector3.right * Time.deltaTime, zAngle, Space.Self);
            //RotatePoint.transform.Rotate(0, 0,zAngle, Space.Self);
        }
        if (Input.GetKey(KeyCode.E)){
            //RotatePoint.transform.Rotate(0, 0,-zAngle, Space.Self);
            //RotatePoint.transform.Rotate(Vector3.left * Time.deltaTime, zAngle, Space.Self);
            transform.Rotate(0, 0, -90 * Time.deltaTime);
        }
    }
}

