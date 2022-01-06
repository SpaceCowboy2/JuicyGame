using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSpawn : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    TextMeshProUGUI scoreText;

    private ScoreAppear scoreFinder;

    private Vector3 spawnPos;

    void Awake ()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = 10f.ToString();
        spawnPos = transform.position;
        StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<TextMeshProUGUI>()));
        StartCoroutine(TextHelium(1f, GetComponent<TextMeshProUGUI>()));
    }

    public IEnumerator TextHelium(float t, TextMeshProUGUI i)
    {
        i.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        while (i.transform.position.y > spawnPos.y/2)
        {
            i.transform.position = new Vector3(transform.position.x, transform.position.y + (Time.deltaTime / t), transform.position.z);
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
