using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action Explosion;

    private void OnMouseDown()
    {
        Explosion?.Invoke();
        Destroy(gameObject);
    }
}
