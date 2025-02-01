using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    private Cube _newCube;
    private float parentScale = 0.5f;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    public void Spawn(Vector3 position, Vector3 localScale)
    {
        int maxNumber = 6;
        int minNumber = 2;

        int randomNumber = Random.Range(minNumber, maxNumber + 1);

        for (int i = 0; i < randomNumber; i++)
        {
            Vector3 randomPosition = position + Random.insideUnitSphere;
            _newCube = Instantiate(_cube, randomPosition, Quaternion.identity);
            _newCube.transform.localScale = localScale * parentScale;

            Rigidbody rigidbody = _newCube.GetComponent<Rigidbody>();

            rigidbody.useGravity = false;
        }
    }
}
