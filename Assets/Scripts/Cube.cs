using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance;
    private Color _meshRenderer;

    public float SplitChance => _splitChance;

    private void Awake()
    {
        _meshRenderer = GetComponent<Color>();
    }

    private void Start()
    {
        _meshRenderer.SetRandomColor();
    }

    public void Break()
    {
        Destroy(gameObject);
    }

    public void UpdateSplitChance(float splitChance)
    {
        _splitChance = splitChance;
    }
}
