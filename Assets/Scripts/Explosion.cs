using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Explosion : MonoBehaviour
{
    private const float ExplosionForce = 700f;
    private const float ExplosionRadius = 10f;

    public void Bang(Vector3 position, Vector3 localScale)
    {
        Collider[] colliders = Physics.OverlapSphere(position, ExplosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                float distance = Vector3.Distance(position, collider.transform.position);

                float forceFactor = 1 - Mathf.Clamp01(distance / ExplosionRadius);

                float finalForce = ExplosionForce * forceFactor / localScale.x;

                rigidbody.AddExplosionForce(finalForce, position, ExplosionRadius);
            }
        }
    }

    public void Blast(List<Rigidbody> rigidbodies, Vector3 position)
    {
        if(rigidbodies !=  null)
        {
            foreach (Rigidbody rigidbody in rigidbodies)
            {
                rigidbody.AddExplosionForce(ExplosionForce, position, ExplosionRadius);
            }

            rigidbodies.Clear();
        }
    }
}
