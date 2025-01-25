using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Vector3 _size;

    private void Update()
    {
        transform.localScale += _size * Time.deltaTime;
    }
}
