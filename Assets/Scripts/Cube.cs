using UnityEngine;

[RequireComponent(typeof(ColorChanger))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance;
    private ColorChanger _color;

    public float SplitChance => _splitChance;

    private void Awake()
    {
        _color = GetComponent<ColorChanger>();
    }

    private void Start()
    {
        _color.SetRandomColor();
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
