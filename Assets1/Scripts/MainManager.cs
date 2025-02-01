using System;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private Spawner _spawner;
    private Exception _exception;
    private Cube _cube;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
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
            _cube = hit.collider.GetComponent<Cube>();

            if (hit.collider.TryGetComponent(out Cube cube))
            {
                _cube.DivisionChance();

                if (_cube.SplitChance > UnityEngine.Random.value)
                {
                    Debug.Log(_cube.transform.position);
                    _spawner.Spawn(_cube.transform.position, _cube.transform.localScale);
                }
            }
        }
    }
}
