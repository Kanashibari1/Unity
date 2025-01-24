using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 _position;

    private void Update()
    {
        transform.position += _position;
    }
}
