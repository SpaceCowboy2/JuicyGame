using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public ParticleSystem deathPS;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
            bubblesExplosion();
    }


    public void bubblesExplosion()
    {
        deathPS.Play();
    }
}
