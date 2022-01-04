using DG.Tweening;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public Vector3 positionToGo;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float socialDistancing;
    private float security = 1;
    private float sinusTime;


    private void Start()
    {
        RandomPosition();
    }

    private void RandomPosition()
    {
        positionToGo = (Random.insideUnitCircle * security) * positionToGo;
        positionToGo = new Vector3(positionToGo.x, positionToGo.y + security);

        foreach (FishMove Fish in FindObjectsOfType<FishMove>())
        {
            if (Fish != this)
            {
                if (Vector3.Distance(positionToGo, Fish.positionToGo) < socialDistancing)
                {
                    security++;
                    RandomPosition();
                    return;
                }

            }
        }
    }

    void Update()
    {
        transform.DOMoveX(positionToGo.x, speed);

        sinusTime += Time.deltaTime;
        if (sinusTime > speed)
        {
            return;
        }
        transform.position = new Vector2(transform.position.x, Mathf.Sin(sinusTime) + positionToGo.y);
    }
}
