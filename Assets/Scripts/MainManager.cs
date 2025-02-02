using System;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private Division _division;
    private Explosion _explosion;
    public event Action<Cube> CubeClicked;

    private void Awake()
    {
        _division = GetComponent<Division>();
        _explosion = GetComponent<Explosion>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleCubeClick();
        }
    }

    private void HandleCubeClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                CubeClicked?.Invoke(cube);
                _explosion.Bang(_division.Rigidbodies);
            }
        }
    }
}
