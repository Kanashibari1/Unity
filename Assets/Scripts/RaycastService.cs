using System.Collections.Generic;
using UnityEngine;

public class RaycastService : MonoBehaviour
{
    private Explosion _explosion;
    private Camera _camera;
    private Spawner _spawner;
    private ClickHandler _clickHandler;
    private Vector3 _localScale;
    private List<Rigidbody> _rigidbody = new List<Rigidbody>();

    private void Awake()
    {
        _camera = Camera.main;
        _clickHandler = GetComponent<ClickHandler>();
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
        RaycastHit hit;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                if (cube.SplitChance > Random.value)
                {
                    _localScale = _spawner.Spawn(cube.transform.position, cube.transform.localScale, cube.SplitChance);
                }

                _explosion.Bang(cube.transform.position, _localScale);

                cube.Break();
            }
        }
    }
}
