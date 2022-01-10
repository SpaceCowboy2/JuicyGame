using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public Vector3 positionToGo;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float socialDistancing;
    private float security = 1;
    private float sinusTime;
    private float randomDepth;


    private void Start()
    {
        StartCoroutine(RandomPathFinding());
        RandomPosition();
        randomDepth = Random.Range(0.0f, 10.0f);
    }

    private void RandomPosition()
    {
        positionToGo = (Random.insideUnitCircle * security) * positionToGo;
        positionToGo = new Vector3(positionToGo.x - Random.Range(0, security), positionToGo.y + security, Random.Range(0.0f,10.0f));

        foreach (FishMove Fish in FindObjectsOfType<FishMove>())
        {
            if (Fish != this)
            {
                if (Vector3.Distance(positionToGo, Fish.positionToGo) < socialDistancing)
                {
                    security++;
                    RandomPosition();
                    return;
                }

            }
        }
    }

    void Update()
    {
        transform.DOMoveX(positionToGo.x, speed);

        sinusTime += Time.deltaTime;
        if (sinusTime > speed)
        {
            return;
        }
        transform.position = new Vector3(transform.position.x, Mathf.Sin(sinusTime) + positionToGo.y, randomDepth);
    }

    private void ChangePosition()
    {
        // Ajouter mouvement de poisson de gauche à droite quand il se déplace
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        positionToGo = new Vector3(spawnX, spawnY, Random.Range(0.0f, 10.0f));
        transform.DOMove(positionToGo,speed);
    }

    IEnumerator RandomPathFinding()
    {
        yield return new WaitForSeconds(5.0f);
        ChangePosition();
        StartCoroutine(RandomPathFinding());
    }
}
