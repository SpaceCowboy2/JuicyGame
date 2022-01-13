using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicJuice : MonoBehaviour
{
    private bool isJuiceMusic = false;

    private void Start()
    {
        SetActive();
    }

    void Update()
    {
        //Debug.Log(isJuiceBG);
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isJuiceMusic = !isJuiceMusic;
            SetActive();
        }
    }

    private void SetActive()
    {
        Camera.main.GetComponent<AudioListener>().enabled = isJuiceMusic;
    }
}
