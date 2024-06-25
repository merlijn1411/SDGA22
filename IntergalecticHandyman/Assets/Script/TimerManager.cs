using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;
    [SerializeField] private TMP_Text timerText;
    private TimeSpan _timeLeft;

    public UnityEvent onTimeZero;
    

    private void Start()
    {
        _timeLeft = new TimeSpan(0, minutes, seconds);
        timerText.text = _timeLeft.ToString(@"mm\:ss");
        StartCoroutine(StartCountdown()); 
    }

    public void StopCountDown()
    {
        StopCoroutine(StartCountdown());
    }
    
    private IEnumerator StartCountdown()
    {
        while (true)
        {
            timerText.text = _timeLeft.ToString(@"mm\:ss");
            _timeLeft = _timeLeft.Subtract(new TimeSpan(0, 0, 1));
            
            yield return new WaitForSeconds(1);

            if (_timeLeft < TimeSpan.Zero)
            {
                timerText.gameObject.SetActive(false);
                onTimeZero.Invoke();
                break;
            }
        }
    }
}
