using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ParticleSystem deathPS;

    [SerializeField]
    private Material[] colors;

    [SerializeField]
    private Material coralColor;

    private void Start()
    {
        int colorindex = Random.Range(0, colors.Length);
        coralColor = colors[colorindex];

        GetComponent<MeshRenderer>().material = coralColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
            deathCoral();
    }


    public void deathCoral()
    {
        deathPS.Play();
        //Faire aparaitre le corail au fond
    }
}
