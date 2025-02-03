using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private const int LKM = 0;
    private Explosion _explosion;
    private Camera _camera;
    private Spawner _spawner;
    private List<Rigidbody> _rigidbody = new List<Rigidbody>();

    private void Awake()
    {
        _camera = Camera.main;
        _spawner = GetComponent<Spawner>();
        _explosion = GetComponent<Explosion>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(LKM))
        {
            HandleCubeClick();
        }
    }

    private void HandleCubeClick()
    {
        RaycastHit hit;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                if (cube.SplitChance > Random.value)
                {
                    _rigidbody = _spawner.Spawn(cube.transform.position, cube.transform.localScale, cube.SplitChance);
                    _explosion.Bang(_rigidbody);
                }

                cube.Break();
            }
        }
    }
}
