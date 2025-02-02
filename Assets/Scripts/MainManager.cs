using System;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private Explosion _explosion;
    public event Action<Cube> CubeClicked;

    private void Awake()
    {
        _explosion = GetComponent<Explosion>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Мышь кликнута один раз!");
            HandleCubeClick();
        }
    }

    private void HandleCubeClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Cube cube = hit.collider.GetComponent<Cube>();

            CubeClicked?.Invoke(cube);
            _explosion.Bang();
        }
    }
}
