using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Explosion : MonoBehaviour
{
    private const float ExplosionForce = 500f;
    private const float ExplosionRadius = 5f;

    public void Bang(Vector3 position, Vector3 localScale)
    {
        Collider[] colliders = Physics.OverlapSphere(position, ExplosionRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                float distance = Vector3.Distance(position, collider.transform.position);

                float forceFactor = 1 - Mathf.Clamp01(distance / ExplosionRadius);

                float finalForce = ExplosionForce * forceFactor / localScale.x;

                rigidbody.AddExplosionForce(finalForce, position, ExplosionRadius);
            }
        }
    }
}
