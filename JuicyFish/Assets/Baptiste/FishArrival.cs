using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishArrival : MonoBehaviour
{

    public static FishArrival Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void FishSpawn()
    {
        Debug.Log("OH LE POISSON");
    }
}
