using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicJuice : MonoBehaviour
{
    private bool isJuiceMusic;

    private void Start()
    {
        SetActive();
    }

    void Update()
    {
        //Debug.Log(isJuiceBG);
        if (Input.GetKeyDown(KeyCode.M))
        {
            isJuiceMusic = !isJuiceMusic;
            SetActive();
        }
    }

    private void SetActive()
    {
        if (isJuiceMusic)
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().Pause();
        }
    }
}
