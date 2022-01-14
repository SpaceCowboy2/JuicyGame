using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class MusicJuice : MonoBehaviour
{
    private bool isJuiceMusic = false;

    private void Awake()
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
        float newVolume = isJuiceMusic ? .5f : 0f;
        foreach (AudioSource source in FindObjectsOfType<AudioSource>())
        {
            source.volume = newVolume;
        }
    }
}
