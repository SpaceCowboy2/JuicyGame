using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishArrival : MonoBehaviour
{
    [SerializeField]
    private GameObject juiceFish;



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

    public void FishSpawn(GameObject killedFish)
    {
        int rotator = 0;
        float posX = 13f;
        if(killedFish.transform.position.x < 0)
        {
            posX *= -1;
            rotator = 180;
        }

        GameObject fish = Instantiate(juiceFish, new Vector3(posX, killedFish.transform.position.y, 0), Quaternion.identity);
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
        
       

        fish.GetComponent<FishMove>().positionToGo = killedFish.transform.position;
    }
}
