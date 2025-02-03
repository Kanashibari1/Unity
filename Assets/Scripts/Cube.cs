using UnityEngine;
public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance;
    private MeshRenderer _meshRenderer;

    public float SplitChance => _splitChance;

    public void Break()
    {
        Destroy(gameObject);
    }

    public void UpdateSplitChance(float splitChance)
    {
        _splitChance = splitChance;
    }

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
        _meshRenderer.material.color = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f);    
    }
}
