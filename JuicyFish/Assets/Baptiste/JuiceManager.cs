using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceManager : MonoBehaviour
{
    //public GameObject Juice1;
    //public GameObject Juice2;
    /*public GameObject Juice3;
    public GameObject Juice4;
    public GameObject Juice5;
    public GameObject Juice6;
    public GameObject Juice7;
    public GameObject Juice8;*/

    [HideInInspector]
    public bool bubblesOn = false;

    private static JuiceManager instance;

    public static JuiceManager i
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //Juice1.SetActive(false);
        //Juice2.SetActive(false);
        /*Juice3.SetActive(false);
        Juice4.SetActive(false);
        Juice5.SetActive(false);
        Juice6.SetActive(false);
        Juice7.SetActive(false);
        Juice8.SetActive(false);*/
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    bool isJuiceActive = true;
        //    isJuiceActive = !isJuiceActive;
        //    JuiceToActivate(Juice1, isJuiceActive);
        //}

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    bool isJuiceActive = true;
        //    isJuiceActive = !isJuiceActive;
        //    JuiceToActivate(Juice2, isJuiceActive);
        //}

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            bubblesOn ^= true;
        }
    }

    void JuiceToActivate(GameObject JuiceActivated, bool stateBool)
    {
        //JuiceActivated.SetActive(stateBool);
    }

}
