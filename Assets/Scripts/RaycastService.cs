using UnityEngine;

[RequireComponent(typeof(ClickHandler))]
[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Explosion))]

public class RaycastService : MonoBehaviour
{
    private const float Divider = 0.5f;
    private Explosion _explosion;
    private Camera _camera;
    private Spawner _spawner;
    private ClickHandler _clickHandler;
    private Vector3 _localScale;

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
                    _localScale = _spawner.Spawn(cube.transform.position, cube.transform.localScale, splitChance);
                }

                _explosion.Bang(cube.transform.position, _localScale);

                cube.Break();
            }
        }
    }
}
