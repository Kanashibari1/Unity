using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Explosion : MonoBehaviour
{
    private float _explosionForce = 5f;
    private List<Rigidbody> _rigidbody = new List<Rigidbody>();
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    public void Bang()
    {
        _rigidbody = _spawner.Rigidbodies;

        foreach (Rigidbody rigidbody in _rigidbody)
        {
            if (rigidbody != null)
            {
                Vector3 directionToExplosion = rigidbody.transform.position - transform.position;
                Vector3 randomDirection = Random.insideUnitSphere;
                Vector3 forceDirection = (directionToExplosion.normalized + randomDirection.normalized).normalized;
                rigidbody.AddForce(forceDirection * _explosionForce, ForceMode.Impulse);
            }
        }

        _rigidbody.Clear();
    }
}
