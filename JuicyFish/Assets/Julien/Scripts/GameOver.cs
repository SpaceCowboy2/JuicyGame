using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameOver : MonoBehaviour {

	public static bool isPlayerDead = false;
	private TextMeshProUGUI gameOver;

	void Start () {
		gameOver = GetComponent<TextMeshProUGUI> ();
		gameOver.enabled = false;
	}

	void Update () {
		if (isPlayerDead) {
			Time.timeScale = 0;
			gameOver.enabled = true;
		}
	}
}
