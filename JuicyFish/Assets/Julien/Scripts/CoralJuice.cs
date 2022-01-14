using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralJuice : MonoBehaviour
{
    public Transform enemyHolder;

    [HideInInspector]
    public bool juiceEnabled = false;

    void Awake()
    {
        SetActive();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            juiceEnabled ^= true;
            SetActive();
        }
    }

    void SetActive()
    {
        foreach (Enemy coral in FindObjectsOfType<Enemy>())
        {
            if (coral.GetComponent<Enemy>().isDead)
            {
                coral.GetComponent<Renderer>().enabled = juiceEnabled;
            }
        }
    }
}
