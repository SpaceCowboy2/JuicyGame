using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Transform player;
	public float speed;
	public float maxBound, minBound;
	public ParticleSystem bubbles;
    public AudioSource playerFireSFX;
    public AudioSource playerDeathSFX;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Start () {
		player = GetComponent<Transform> ();
	}

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");

		if (player.position.x < minBound && h < 0)
			h = 0;
		else if (player.position.x > maxBound && h > 0)
			h = 0;

		player.position += Vector3.right * h * speed;
	}

	void Update(){

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, Quaternion.Euler(0f,-90f,0f));
            if (JuiceManager.i.bubblesOn)
            {
    			bubbles.Play();
            }
			playerFireSFX.Play();
		}
	}

}
