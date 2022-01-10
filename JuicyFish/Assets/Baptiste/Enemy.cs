using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public ParticleSystem deathPS;

    [SerializeField]
    private Material[] deadColors;

    [SerializeField]
    private Material[] liveColors;

    [SerializeField]
    private Material coralColor;

    [SerializeField]
    private GameObject coralParent;


    private int colorIndex;
    private float speed = 4;
    private Material mat1;
    private Material mat2;

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
        gameObject.tag = "Untagged";
        Vector3 deathpos = transform.position;
        deathPS.Play();
        transform.SetParent(coralParent.transform);
        transform.DOMoveY(-6.5f, speed);
        transform.DOMoveX(Random.Range((deathpos.x - 4f), (deathpos.x + 4f)), speed);

        mat1 = deadColors[colorIndex];
        mat2 = liveColors[colorIndex];
        GetComponent<MeshRenderer>().material = mat2;
        //GetComponent<MeshRenderer>().material.Lerp(mat1, mat2, Mathf.PingPong(Time.time, speed) / speed);
    }
}
