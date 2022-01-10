﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	private Transform bullet;
	public float speed;

	void Start () {
		bullet = GetComponent<Transform> ();
	}

	void FixedUpdate(){
		bullet.position += Vector3.up * speed;

		if (bullet.position.y >= 10)
			Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy") {
			FishArrival.Instance.FishSpawn(other.gameObject);
			ScoreAppear.Instance.ShowScore(other.gameObject);

			//other.gameObject.GetComponent<MeshRenderer>().enabled = false;
			//other.gameObject.GetComponent<Collider>().enabled = false;

			//Destroy(other.gameObject, 2f);
			Destroy (gameObject);
			PlayerScore.playerScore += 10;
		} else if (other.tag == "Base")
			Destroy (gameObject);
	}
}
