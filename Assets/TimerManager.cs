using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float Timer;
    public float LapTime;
    public float BestLapTime;
    public bool IsStarted;
    public bool IsFinished;

    private void Awake()
    {
        IsStarted = false;
        IsFinished = false;
        Timer = 0;
        if(BestLapTime == 0)
        {
            BestLapTime = Mathf.Infinity;
        }
    }

    private void Update()
    {
        if(IsStarted == true)
        {
            Timer = Timer += Time.deltaTime;
        }
    }

    public void Finished()
    {
        LapTime = Timer;
        BestLapChecker();
    }

    private void BestLapChecker()
    {
        if(LapTime != 0)
        {
            if(LapTime < BestLapTime)
            {
                BestLapTime = LapTime;
                PlayerPrefs.SetFloat("BestLapTime1", BestLapTime);
            }
        }
    }
}
