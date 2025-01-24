using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Multiactioncube : MonoBehaviour
{
    private float _increase =+ 0.01f;
    void Update()
    {
        var newPosition = transform.position;
        newPosition.z += 0.05f;
        transform.position = newPosition;

        transform.RotateAround(transform.position, transform.up, 2f + Time.deltaTime);

        transform.localScale += new Vector3(_increase, _increase, _increase);
    }
}
