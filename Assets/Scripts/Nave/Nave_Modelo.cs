using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave_Modelo : MonoBehaviour {

		public float speed;
		public float Zspeed;
		public int life = 3;
		public float H_movement;
		public float V_Movement;
		public float Xmin, Xmax, Ymin, Ymax, Zmin, Zmax;
		public float zAngle;

		public float zRotation;

		public float RotationSpeed;


		public Rigidbody Rig;

		public bool isDead;
		public bool endGame;

		public Transform allColliders;

		public Camera_Movement cam;

		public Vector3 randomRotation;

		void Start()
		{

			H_movement = Input.GetAxis("Horizontal");
			V_Movement = Input.GetAxis("Vertical");

			isDead = false;
			endGame = false;

			Rig = GetComponent<Rigidbody>();

			InvokeRepeating("Acceleration", 1, 6);

			Physics.IgnoreLayerCollision(9, 10);
		}

}
