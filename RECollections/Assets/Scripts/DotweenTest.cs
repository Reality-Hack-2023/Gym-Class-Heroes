using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DotweenTest : MonoBehaviour
{
    public float time = 3.0f;
    public float distance = 1.0f;
    // Start is called before the first frame update

    private void Start()
    {
        //Tween();
    }
    public Vector3 RandomPoint()
    {
        float randomX = Random.Range(0, distance);
        float randomY = Random.Range(0, distance);
        float randomZ = Random.Range(0, distance);
        return new Vector3(randomX, randomY, randomZ);
    }

    public void Tween()
    {
        transform.DOMove(RandomPoint() + transform.position, time);
    }
}
