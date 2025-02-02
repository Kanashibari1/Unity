using UnityEngine;
public class Cube : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

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

    public void Break()
    {
        Destroy(gameObject);
    }
}
