using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Spawner : MonoBehaviour
{
    private const float ParentScale = 0.5f;
    private List<Rigidbody> rigidbodies = new();

    [SerializeField] private Cube _cubePrefab;

    public List<Rigidbody> Spawn(Vector3 position, Vector3 localScale, float splitChance)
    {
        int maxNumber = 6;
        int minNumber = 2;

        int randomNumber = Random.Range(minNumber, maxNumber + 1);

        for (int i = 0; i < randomNumber; i++)
        {
            Vector3 randomPosition = position + Random.insideUnitSphere;
            Cube cube = Instantiate(_cubePrefab, randomPosition, Quaternion.identity);
            cube.transform.localScale = localScale * ParentScale;
            cube.UpdateSplitChance(splitChance);
            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

            rigidbody.useGravity = false;

            rigidbodies.Add(rigidbody);
        }

        return rigidbodies;
    }
}
