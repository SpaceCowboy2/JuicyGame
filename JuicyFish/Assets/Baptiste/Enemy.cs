using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public ParticleSystem deathPS;
    public AudioSource enemyDeathSFX;

    [SerializeField]
    private Material[] deadColors;

    [SerializeField]
    private Material[] liveColors;

    [SerializeField]
    private Material coralColor;

    [SerializeField]
    private GameObject coralParent;

    [HideInInspector]
    public Vector2 newPos;

    private int colorIndex;
    private float speed = 4;
    private Material mat1;
    private Material mat2;

    [Min(0.25f)]public float socialDistancing;
    private int security = 0;

    private void Start()
    {
        colorIndex = Random.Range(0, deadColors.Length);
        coralColor = deadColors[colorIndex];

        GetComponent<MeshRenderer>().material = coralColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
            deathCoral();
    }


    public void deathCoral()
    {
        //Vector3 deathpos = transform.position;
        if (JuiceManager.i.bubblesOn)
        {
            deathPS.Play();
        }
        enemyDeathSFX.Play();

        RandomPosition();

        mat1 = deadColors[colorIndex];
        mat2 = liveColors[colorIndex];
        GetComponent<MeshRenderer>().material = mat2;

        //GetComponent<MeshRenderer>().material.Lerp(mat1, mat2, Mathf.PingPong(Time.time, speed) / speed);
    }

    private void RandomPosition()
    {
        Vector3 deathpos = transform.position;

        newPos = new Vector2(Random.Range((deathpos.x - 4f - security), (deathpos.x + 4f + security)), -6.5f);

        transform.SetParent(coralParent.transform);
        transform.DOMove(newPos, speed);

        foreach (Enemy Enemy in FindObjectsOfType<Enemy>())
        {
            if (Enemy != this)
            {
                if (Vector3.Distance(newPos, Enemy.newPos) < Random.Range(0.25f, socialDistancing))
                {
                    security++;
                    RandomPosition();
                    return;
                }
            }
        }
    }
}
