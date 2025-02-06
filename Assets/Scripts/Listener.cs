using System;
using UnityEngine;

public class Listener : MonoBehaviour
{
    private const int MouseButton = 0;

    public event Action CubeClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton))
        {
            CubeClicked?.Invoke();
        }
    }
}
