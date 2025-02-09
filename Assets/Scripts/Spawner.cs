using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private ObjectPool<Cube> _pool;
    private float _spawnTime = 1f;
    private float _minRandomPosition = -15f;
    private float _maxRandomPosition = 15f;
    private int _positionY = 15;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(Create, OnGetCube, Release, Destroy, true);
    }

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void OnGetCube(Cube cube)
    {
        cube.OnCubeDeactivate += OnCubeDeactivated;
        cube.transform.position = new Vector3(Random.Range(_minRandomPosition, _maxRandomPosition), _positionY, Random.Range(_minRandomPosition, _maxRandomPosition));
        cube.gameObject.SetActive(true);
    }

    private void OnCubeDeactivated(Cube cube)
    {
        cube.OnCubeDeactivate -= OnCubeDeactivated;
        _pool.Release(cube);
    }

    private void Release(Cube cube)
    {
        cube.gameObject.SetActive(false);
    }

    private Cube Create()
    {
        return GameObject.Instantiate(_cubePrefab);
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            WaitForSeconds waitForSeconds = new(_spawnTime);
            _pool.Get();
            yield return waitForSeconds;
        }
    }
}
