using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyController : MonoBehaviour {

	private Transform enemyHolder;
	private bool canGoRight = true;
	private bool canGoDown = false;
	public float speed;

	public GameObject shot;
	public TextMeshProUGUI winText;
    public AudioSource enemyFireSFX;
	public float fireRate = 0.997f;

	void Start () {
		winText.enabled = false;
		//InvokeRepeating ("MoveEnemy", 0.1f, 0.5f);
		enemyHolder = GetComponent<Transform> ();
		StartCoroutine(MoveEnemyRight());
		InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
	}

	void MoveEnemy()
	{
		foreach (Transform enemy in enemyHolder) {

			//EnemyBulletController called too?
			if (Random.value > fireRate) {
				Instantiate (shot, enemy.position, Quaternion.Euler(180f,-90f,0f));
				enemyFireSFX.Play();
			}

            if (enemy.position.y <= -4) {
				GameOver.isPlayerDead = true;
				Time.timeScale = 0;
			}
		}


		if (enemyHolder.childCount == 0) {
			winText.enabled = true;
		}
	}

	IEnumerator MoveEnemyDown()
    {
		float timeElapsed = 0.0f;
		float lerpDuration = 1.0f;
		Vector3 actualPos = enemyHolder.position;

		while(timeElapsed < lerpDuration)
        {
			enemyHolder.position = Vector3.Lerp(actualPos, actualPos + Vector3.down * 0.5f, timeElapsed / lerpDuration);
			timeElapsed += Time.deltaTime;
			yield return null;
		}
		
		if(enemyHolder.position.x < 1)
        {
			StartCoroutine(MoveEnemyRight());
		}
		else
        {
			StartCoroutine(MoveEnemyLeft());
		}
		
		yield return null;
    }

	IEnumerator MoveEnemyRight()
	{
		float timeElapsed = 0.0f;
		float lerpDuration = 5.0f;

		Vector3 actualPos = enemyHolder.position;

		while (timeElapsed < lerpDuration)
		{
			enemyHolder.position = Vector3.Lerp(actualPos, new Vector3(10,enemyHolder.position.y,0), timeElapsed / lerpDuration);
			timeElapsed += Time.deltaTime;
			yield return null;
		}

		StartCoroutine(MoveEnemyDown());
		yield return null;
	}

	IEnumerator MoveEnemyLeft()
	{
		float timeElapsed = 0.0f;
		float lerpDuration = 5.0f;

		Vector3 actualPos = enemyHolder.position;

		while (timeElapsed < lerpDuration)
		{
			enemyHolder.position = Vector3.Lerp(actualPos, new Vector3(0.5f, enemyHolder.position.y, 0), timeElapsed / lerpDuration);
			timeElapsed += Time.deltaTime;
			yield return null;
		}

		StartCoroutine(MoveEnemyDown());
		yield return null;
	}
}
