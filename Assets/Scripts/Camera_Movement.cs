using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour {
    public Transform target;
    public Transform endPos;
    /*public float smoothSpeed = 0.125f;
    public Vector3 offset;*/
    public bool shake;
    private float timer;


    [Range(0.1f, 1f)]
    public float cd;

    [Range(0.01f, 0.50f)]
    public float RangeX;

    [Range(0.01f, 0.50f)]
    public float rangeY;
    //new movement
    Vector3 defaultDistance = new Vector3(0, 1.2f, -10f);
    public Vector3 velocity = Vector3.one;
    [SerializeField] float distanceDamp = 0.85f;


    Transform cam;



    public Nave nave;

    void Awake () {
        cam = transform;	
	}
	
	// Update is called once per frame

    void Update() {
        Rotate();
        endGame();
    }

	void LateUpdate () {

        if(nave.isDead == false){
            Follow();
            CamShake();
        }

    }

    void CamShake()
    {
        if (shake)
        {
            Vector3 cp = cam.position;

            cp.x += Random.Range(-RangeX, RangeX);
            cp.y += Random.Range(-rangeY, rangeY);

            cam.position = cp;

            timer += Time.deltaTime;
        }

        if (timer >= cd)
        {
            shake = false;
            timer = 0f;
        }
    }

    void Follow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(cam.position, toPos, ref velocity, distanceDamp);
        cam.position = curPos;

        cam.LookAt(target,target.up);
    }

    public void Rotate()
    {
        if (Input.GetKey(KeyCode.Q)){
            transform.Rotate(0, 0, 90 * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.E)){
            transform.Rotate(0, 0, -90 * Time.deltaTime);
        }
    }

    void endGame()
    {
        if (nave.endGame == true)
        {
            transform.position = endPos.position;
            transform.rotation = endPos.rotation;
        }
    }



}
