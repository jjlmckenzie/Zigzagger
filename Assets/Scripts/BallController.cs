﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public GameObject particle;

	[SerializeField]
	private float speed;
	bool started;
	Rigidbody rb;
	bool gameOver;

	void Awake() {
		rb = GetComponent<Rigidbody> ();
	
	
	}

	// Use this for initialization
	void Start () {
		started = false;
		gameOver = false;
	}
	
	// Update is called once per frame

	public void BallRolling() {
		rb.velocity = new Vector3 (0, 0, speed);
		started = true;
		GameManager.instance.StartGame ();
	}

	void Update () {

		//if (!started) {
		//	if(Input.GetMouseButtonDown(0)){
		//		rb.velocity = new Vector3 (speed, 0, 0);
		//		started = true;
		//		GameManager.instance.StartGame ();
		//
		//	}
		//}

		Debug.DrawRay (transform.position, Vector3.down, Color.red);

		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {
			gameOver = true;
			rb.velocity = new Vector3 (0,-25f,0);

			GameManager.instance.gameOver = true;
			GameManager.instance.GameOver ();


			Camera.main.GetComponent<CameraFollow> ().gameOver = true;
			//Need to cancel spawning


		}


		if(Input.GetMouseButtonDown (0) && !gameOver){
			SwitchDirection ();
		}
	}

	//On touch/click, change direction
	void SwitchDirection() {
		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0, 0);
		} else if (rb.velocity.x > 0) {
			rb.velocity = new Vector3 (0, 0, speed);
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "SmallCube") {
			//GameObject part = Instantiate (particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy (col.gameObject);
			//Destroy (part, 1f);

			ScoreManager.instance.score += 5;

		}

	}
}
