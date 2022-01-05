using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicJuice : MonoBehaviour
{
    public GameObject juiceMusic;
    public AudioClip musicClip;
    public bool isJuiceMusic;

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
        juiceMusic.GetComponent<AudioSource>().PlayOneShot(musicClip);
    }
}
