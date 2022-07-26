using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTextDisplay : MonoBehaviour
{
    [SerializeField]
    private Text _finishText;
    [SerializeField]
    private Text _finishText2;
    [SerializeField]
    private string _finishMessage;
    [SerializeField]
    private TimerManager _timerManager;

    private void Awake()
    {
        if(_timerManager == null)
        {
            _timerManager = GameObject.Find("TimerManager").GetComponent<TimerManager>();
        }
    }

    private void Start()
    {
        _finishText.text = ("Your actual time is " + _timerManager.LapTime.ToString("00.00"));
        _finishText2.text = ("Your best Lap time is " + _timerManager.BestLapTime.ToString("00.00"));
    }



}
