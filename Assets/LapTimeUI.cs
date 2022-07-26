using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeUI : MonoBehaviour
{
    [SerializeField]
    private Text _currentTime;
    private TimerManager _timerManager;
    private Color _originalColor;

    private void Awake()
    {
        if (_timerManager == null)
        {
            _timerManager = GameObject.Find("TimerManager").GetComponent<TimerManager>();
        }
        _originalColor = new Color32(247, 255, 0, 255);
    }

    void Update()
    {
        _currentTime.text = _timerManager.Timer.ToString("00.00");
    }

    public IEnumerator TexTColorChangeOnHit()
    {
        bool coroutineIsActive = false;
        if (coroutineIsActive == false)
        {
            coroutineIsActive = true;
            //var originalColor = _currentTime.color;
            _currentTime.color = new Color32(255, 75, 0, 255);
            yield return new WaitForSeconds(2f);
            _currentTime.color = _originalColor;
            coroutineIsActive = false;
        }
    }
}
