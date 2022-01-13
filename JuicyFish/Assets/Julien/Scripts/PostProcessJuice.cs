using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessJuice : MonoBehaviour
{
    public Transform postProcessGameObject;

    private bool juiceEnabled = false;

    void Awake()
    {
        SetActive();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            juiceEnabled ^= true;
            SetActive();
        }
    }

    void SetActive()
    {
        postProcessGameObject.GetComponent<Volume>().enabled = juiceEnabled;
    }
}
