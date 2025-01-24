using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForward : MonoBehaviour
{
    void Update()
    {
        var newPosition = transform.position;
        newPosition.z -= 0.05f;
        transform.position = newPosition;
    }
}
