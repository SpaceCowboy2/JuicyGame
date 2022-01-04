using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public Vector3 positionToGo;
    [SerializeField]
    private float speed;

    void Start()
    {
        //positionToGo = ;
    }


    void Update()
    {
        Debug.Log(positionToGo);
        speed += Time.deltaTime;
        Vector3.Lerp(transform.position, Vector3.zero, speed);
    }
}
