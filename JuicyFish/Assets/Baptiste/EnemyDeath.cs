using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public static EnemyDeath InstanceED;
    public ParticleSystem deathPS;

    public void bubblesExplosion()
    {
        Debug.Log("OUi");
        deathPS.Play();
    }
}
