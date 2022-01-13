using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishArrival : MonoBehaviour
{
    [SerializeField]
    private GameObject[] juiceFish;

    public Material fishAAnimMaterial;
    public Material fishAMaterial;
    public Material fishBAnimMaterial;
    public Material fishBMaterial;

    private List<MeshRenderer> aFishRenderers = new List<MeshRenderer>();
    private List<MeshRenderer> bFishRenderers = new List<MeshRenderer>();

    private bool isAnimShaderEnabled = false;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            isAnimShaderEnabled ^= true;
            ChangeMaterials();
        }
    }

    private void ChangeMaterials()
    {
        if (isAnimShaderEnabled)
        {
            foreach (MeshRenderer rend in aFishRenderers)
            {
                rend.material = fishAAnimMaterial;
            }

            foreach (MeshRenderer rend in bFishRenderers)
            {
                rend.material = fishBAnimMaterial;
            }
        }
        else
        {
            foreach (MeshRenderer rend in aFishRenderers)
            {
                rend.material = fishAMaterial;
            }

            foreach (MeshRenderer rend in bFishRenderers)
            {
                rend.material = fishBMaterial;
            }
        }
    }

    public void FishSpawn(GameObject killedFish)
    {
        int rotator = 0;
        float posX = 13f;
        if(killedFish.transform.position.x < 0)
        {
            posX *= -1;
            rotator = 180;
        }

        int fishAorB = Random.Range(0, juiceFish.Length);
        GameObject fishPrefab = juiceFish[fishAorB];
        GameObject fish = Instantiate(fishPrefab, new Vector3(posX, killedFish.transform.position.y, 0), Quaternion.identity);
        //fish.transform.rotation = Quaternion.Euler(fish.transform.rotation.x, fish.transform.rotation.y  + rotator, 90);
        int tworotations = Random.Range(0, 2);
        
        if(tworotations == 0)
        {
            fish.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if(tworotations == 1)
        {
            fish.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        if (fishAorB == 0)
        {
            aFishRenderers.Add(fish.GetComponent<MeshRenderer>());
        }
        else
        {
            bFishRenderers.Add(fish.GetComponent<MeshRenderer>());
        }

        fish.GetComponent<FishMove>().positionToGo = killedFish.transform.position;
    }
}
