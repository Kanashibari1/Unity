using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Explosion : MonoBehaviour
{
    private float _explosionForce = 500f;
    private float _explosionRadius = 5f;
    [SerializeField] private ParticleSystem _effect;

    public void Bang(Vector3 position, Vector3 localScale)
    {
        Collider[] colliders = Physics.OverlapSphere(position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if (rb != null)
            {
                float distance = Vector3.Distance(position, collider.transform.position);

                float forceFactor = 1 - Mathf.Clamp01(distance / _explosionRadius);

                float finalForce = _explosionForce * forceFactor / localScale.x;

                rb.AddExplosionForce(finalForce, position, _explosionRadius);

                Instantiate(_effect, position, transform.rotation);
            }
        }
    }
}
