using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _newCubes;
    private Color _color;
    private float _splitChance = 1.0f;
    private Explosion _explosion;

    private void Start()
    {
        _explosion = GetComponent<Explosion>();
    }

    private void OnEnable()
    {
        if (_newCubes != null)
        {
            _newCubes.Explosion += Spawn;
        }
    }

    private void OnDisable()
    {
        if (_newCubes != null)
        {
            _newCubes.Explosion -= Spawn;
        }
    }

    public void Spawn()
    {
        int maxNumber = 7;
        int minNumber = 2;

        if (Random.value < _splitChance)
        {
            int randomNumber = Random.Range(minNumber, maxNumber);
            Vector3 explosionOrigin = transform.position;

            for (int i = 0; i < randomNumber; i++)
            {
                Vector3 randomPosition = transform.position + Random.insideUnitSphere;
                Cube newCube = Instantiate(_newCubes, randomPosition, Quaternion.identity);
                newCube.transform.localScale = transform.localScale * 0.5f;

                _color = new Color(Random.value, Random.value, Random.value);
                newCube.GetComponent<MeshRenderer>().material.color = _color;

                Rigidbody rigidbody = newCube.GetComponent<Rigidbody>();

                if (rigidbody == null)
                {
                    rigidbody = newCube.gameObject.AddComponent<Rigidbody>();
                }

                rigidbody.useGravity = false;

            }

            _explosion.Bang(transform.position);
            _splitChance *= 0.5f;
        }
    }
}
