using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField] private Vector3 _scale;
    void Update()
    {
        transform.localScale += _scale;
    }
}
