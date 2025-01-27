using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private float _pauseTimer = 0;
    private float _runTimer = 0;
    private bool _isWorking = false;
    private Coroutine _timerCoroutine;
    private WaitForSeconds _wait = new WaitForSeconds(0.5f);
    public event Action Display;

    public float RunTimer => _runTimer;

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

            Display?.Invoke();

            yield return _wait;
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

            StopCoroutine(Count());
        }
    }
}
