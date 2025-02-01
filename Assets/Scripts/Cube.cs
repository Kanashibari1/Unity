using UnityEngine;
public class Cube : MonoBehaviour
{
    private float _splitChance = 1.0f;
    private float _divider = 0.5f;
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
        _meshRenderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);    
    }

    public void DivisionChance()
    {
        _splitChance *= _divider;
    }
}
