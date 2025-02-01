using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Explosion : MonoBehaviour
{
    private float _radiusExplosion = 2f;

    public void Bang(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, _radiusExplosion);

        foreach (Collider collider in colliders)
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                Vector3 randomDirection = collider.transform.position - position;
                rigidbody.AddForce(randomDirection * _radiusExplosion, ForceMode.Impulse);
            }
        }
    }
}
