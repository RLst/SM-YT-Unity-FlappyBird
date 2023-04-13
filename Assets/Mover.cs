using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed = -1;

    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }
}
