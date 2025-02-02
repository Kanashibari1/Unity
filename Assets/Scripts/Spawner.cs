using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    private float parentScale = 0.5f;
    private List<Rigidbody> rigidbodies = new List<Rigidbody>();

    public List<Rigidbody> Spawn(Vector3 position, Vector3 localScale)
    {
        int maxNumber = 6;
        int minNumber = 2;

        int randomNumber = Random.Range(minNumber, maxNumber + 1);

        for (int i = 0; i < randomNumber; i++)
        {
            Vector3 randomPosition = position + Random.insideUnitSphere;
            Cube cube = Instantiate(_cube, randomPosition, Quaternion.identity);
            cube.transform.localScale = localScale * parentScale;

            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

            rigidbodies.Add(rigidbody);

            rigidbody.useGravity = false;
        }

        return rigidbodies;
    }
}
