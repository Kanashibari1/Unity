using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Explosion : MonoBehaviour
{
    private float _explosionForce = 500f;
    private float _radiuse = 500f;

    public void Bang(List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            if (rigidbody != null)
            {
                Vector3 directionToExplosion = rigidbody.transform.position - transform.position;
                Vector3 randomDirection = Random.insideUnitSphere;
                Vector3 forceDirection = (directionToExplosion.normalized + randomDirection.normalized).normalized;

                rigidbody.AddExplosionForce(_explosionForce, forceDirection, _radiuse);
            }
        }

        rigidbodies.Clear();
    }
}
