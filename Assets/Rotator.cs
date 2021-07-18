using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float[] Speed;

    private void Update()
    {
        transform.Rotate(0f, 0f, Speed[Random.Range(0, Speed.Length)] * Time.deltaTime);
    }
}
