using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private float _pauseTimer = 0;
    private float _runTimer = 0;
    private bool _isWorking = false;
    private Coroutine _timerCoroutine;

    private void Start()
    {
        _isWorking = true;

        StartCoroutine(Count());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isWorking)
            {
                PauseTimer();
            }
            else
            {
                ResumeTimer();
            }
        }
    }

    private IEnumerator Count()
    {
        while (_isWorking)
        {
            _runTimer++;

            DisplayCount(_runTimer);

            yield return new WaitForSeconds(0.5f);
        }
    }

    private void ResumeTimer()
    {
        if (!_isWorking)
        {
            _isWorking = true;
            _runTimer = _pauseTimer;
            _timerCoroutine = StartCoroutine(Count());
        }
    }

    private void PauseTimer()
    {
        if (_isWorking)
        {
            _isWorking = false;
            _pauseTimer = _runTimer;

            StopAllCoroutines();
        }
    }

    private void DisplayCount(float count)
    {
        _text.text = count.ToString("");
    }
}
