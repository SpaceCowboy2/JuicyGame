using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrounfJuice : MonoBehaviour
{
    public GameObject juiceBackground;
    public bool isJuiceBG;

    private void Start()
    {
        isJuiceBG = false;
        SetActive();
    }

    void Update()
    {
        //Debug.Log(isJuiceBG);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJuiceBG = !isJuiceBG;
            SetActive();
        }
    }

    private void SetActive()
    {
        juiceBackground.SetActive(isJuiceBG);
    }
}
