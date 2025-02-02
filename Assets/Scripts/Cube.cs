using UnityEngine;
public class Cube : MonoBehaviour
{
    private float _splitChance = 1.0f;
    private MeshRenderer _meshRenderer;

    public float SplitChance => _splitChance;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        SetRandomColor();
    }

    private void SetRandomColor()
    {
        _meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);    
    }

    public void Break()
    {
        Destroy(gameObject);
    }
}
