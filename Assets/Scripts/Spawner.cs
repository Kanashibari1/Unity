using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    private float _parentScale = 0.5f;
    private const float _divider = 0.5f;

    public Vector3 Spawn(Vector3 position, Vector3 localScale, float splitChance)
    {
        Vector3 localScale1 = new();
        splitChance *= _divider;
        int maxNumber = 6;
        int minNumber = 2;

        int randomNumber = Random.Range(minNumber, maxNumber + 1);

        for (int i = 0; i < randomNumber; i++)
        {
            Vector3 randomPosition = position + Random.insideUnitSphere;
            Cube cube = Instantiate(_cube, randomPosition, Quaternion.identity);
            cube.transform.localScale = localScale * _parentScale;
            cube.UpdateSplitChance(splitChance);
            cube.GetComponent<Rigidbody>();
            localScale1 = cube.transform.localScale;
        }

        return localScale1;
    }
}
