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
			Destroy (other.gameObject);
			Destroy (gameObject);
			PlayerScore.playerScore += 10;
			FishArrival.Instance.FishSpawn();
		} else if (other.tag == "Base")
			Destroy (gameObject);
	}
}
