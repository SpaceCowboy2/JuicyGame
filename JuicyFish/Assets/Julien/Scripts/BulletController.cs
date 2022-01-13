using System.Collections;
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
		if (other.CompareTag("Enemy")) {
			other.enabled = false;

			FishArrival.Instance.FishSpawn(other.gameObject);

			if(other.GetComponent<Enemy>() != null)
			ScoreAppear.Instance.ShowScore(other.gameObject);

			Destroy(gameObject);
			//Destroy(other.gameObject, 2f);
			PlayerScore.playerScore += 10;
		} else if (other.tag == "Base")
			Destroy (gameObject);
	}
}
