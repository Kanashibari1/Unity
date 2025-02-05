using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Spawner : MonoBehaviour
{
    private const float ParentScale = 0.5f;
    [SerializeField] private Cube _cube;

    public Vector3 Spawn(Vector3 position, Vector3 localScale, float splitChance)
    {
        Vector3 localScale1 = new();
        int maxNumber = 6;
        int minNumber = 2;

        int randomNumber = Random.Range(minNumber, maxNumber + 1);

        for (int i = 0; i < randomNumber; i++)
        {
            Vector3 randomPosition = position + Random.insideUnitSphere;
            Cube cube = Instantiate(_cube, randomPosition, Quaternion.identity);
            cube.transform.localScale = localScale * ParentScale;
            cube.UpdateSplitChance(splitChance);
            cube.GetComponent<Rigidbody>();
            localScale1 = cube.transform.localScale;
        }

        return localScale1;
    }
}
