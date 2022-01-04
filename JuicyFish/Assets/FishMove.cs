using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FishMove : MonoBehaviour
{
    public Vector3 positionToGo;
    [SerializeField]
    private float speed;

    private float sinusTime;
    private void Start()
    {
        positionToGo = (Random.insideUnitCircle * 2) * positionToGo;


    }


    void Update()
    { 
        transform.DOMoveX(positionToGo.x, speed);

        sinusTime += Time.deltaTime;
        if(sinusTime > speed)
        {
            return;
        }
        transform.position = new Vector2(transform.position.x, Mathf.Sin(sinusTime) + positionToGo.y);
    }
}
