using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAppear : MonoBehaviour
{
    [SerializeField]
    private float scoreToShow;
    [SerializeField]
    private GameObject textToShow;
    [SerializeField]
    private GameObject textParent;

    public static ScoreAppear Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ShowScore(GameObject killedFish)
    {
        //scoreToShow = killedFish.
        Vector3 spawnPosition = killedFish.transform.position;
        TextMeshProUGUI tempText = Instantiate(textToShow, spawnPosition, Quaternion.identity).GetComponent<TextMeshProUGUI>();
        tempText.transform.SetParent(textParent.transform);
    }



}
