using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralJuice : MonoBehaviour
{
    public Transform enemyHolder;

    private bool juiceEnabled = false;

    void Awake()
    {
        //SetActive();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha8))
        //{
        //    juiceEnabled ^= true;
        //    SetActive();
        //}
    }

    void SetActive()
    {
        foreach (Transform coral in enemyHolder)
        {
            if (coral.GetComponent<Enemy>().isDead)
            {
                coral.GetComponent<MeshRenderer>().enabled = juiceEnabled;
            }
        }
    }
}
