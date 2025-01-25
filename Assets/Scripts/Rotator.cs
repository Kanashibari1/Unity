using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _turn;

    private void Update()
    {
        transform.Rotate(_turn * Time.deltaTime);
    }
}
