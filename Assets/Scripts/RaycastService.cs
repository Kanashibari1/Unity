using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Listener))]
[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Explosion))]

public class RaycastService : MonoBehaviour
{
    private const float Divider = 0.5f;

    private Explosion _explosion;
    private Camera _camera;
    private Spawner _spawner;
    private Listener _clickHandler;

    private void Awake()
    {
        _camera = Camera.main;
        _clickHandler = GetComponent<Listener>();
        _spawner = GetComponent<Spawner>();
        _explosion = GetComponent<Explosion>();
    }

    private void OnEnable()
    {
        _clickHandler.CubeClicked += HandleCubeClick;
    }

    private void OnDisable()
    {
        _clickHandler.CubeClicked -= HandleCubeClick;
    }

    private void HandleCubeClick()
    {
        float splitChance;
        RaycastHit hit;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                if (cube.SplitChance > Random.value)
                {
                    splitChance = cube.SplitChance;
                    splitChance *= Divider;
                    List<Rigidbody> rigidbody = _spawner.Spawn(cube.transform.position, cube.transform.localScale, splitChance);
                    _explosion.Blast(rigidbody, cube.transform.position);
                }
                else
                {
                    _explosion.Bang(cube.transform.position, cube.transform.localScale);
                }

                cube.Break();
            }
        }
    }
}
