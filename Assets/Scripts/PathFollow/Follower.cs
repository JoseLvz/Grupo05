using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

    public PathFollowCreator PathFollow;
    public Nave nave;
    public Transform target;
    public int currentWayPointID = 0;

    public float zSpeed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;

    Vector3 last_position;
    Vector3 current_position;

    void Start()
    {
        //PathFollow = GameObject.Find(pathName).GetComponent<PathFollowCreator>();
        last_position = transform.position;

        InvokeRepeating("F_aceleration", 1, 4);
    }

    void Update()
    {
        if (nave.isDead == false)
        {
            float distance = Vector3.Distance(PathFollow.path_objs[currentWayPointID].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, PathFollow.path_objs[currentWayPointID].position, zSpeed * Time.deltaTime);

            var rotation = Quaternion.LookRotation(PathFollow.path_objs[currentWayPointID].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            //transform.LookAt(PathFollow.path_objs[currentWayPointID].position);

            if (distance <= reachDistance)
            {
                currentWayPointID++;
            }

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,target.transform.position, 6*Time.deltaTime);
;        }

        /*float distance = Vector3.Distance(PathFollow.path_objs[currentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathFollow.path_objs[currentWayPointID].position, zSpeed * Time.deltaTime);

        var rotation = Quaternion.LookRotation(PathFollow.path_objs[currentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        //transform.LookAt(PathFollow.path_objs[currentWayPointID].position);

        if (distance <= reachDistance)
        {
            currentWayPointID++;
        }*/

    }

    public void F_aceleration()
    {
        if (nave.isDead == false)
        {
            zSpeed++;
        }
    }

}
