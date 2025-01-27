using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.Display += DisplayCount;
    }

    private void OnDisable()
    {
        _counter.Display -= DisplayCount;
    }

    public void DisplayCount()
    {
        float runTime = _counter.RunTimer;
        _text.text = runTime.ToString("");
    }
}
