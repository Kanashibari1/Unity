using UnityEngine;

public class Division : MonoBehaviour
{
    private float _splitChance = 1.0f;
    private float _divider = 0.5f;
    private MainManager _mainManager;
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        _mainManager = GetComponent<MainManager>();
    }

    private void OnEnable()
    {
        _mainManager.CubeClicked += SplitChance;
    }
    private void OnDisable()
    {
        _mainManager.CubeClicked += SplitChance;
    }

    private void SplitChance(Cube cube)
    {
        if (cube == null) return;

        _splitChance *= _divider;

        cube.Break();

        if (_splitChance > Random.value)
        {
            _spawner.Spawn(cube.transform.position, cube.transform.localScale);
        }
    }
}
