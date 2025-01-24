using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForward : MonoBehaviour
{
    [SerializeField] private Vector3 _newPosition;
    private void Update()
    {
        transform.position += _newPosition;
    }
}
