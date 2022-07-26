using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollardTimerOnCollision : MonoBehaviour
{
    private bool _afterCollision;
    [SerializeField]
    private TimerManager _timerManager;
    [SerializeField]
    private LapTimeUI _lapTimeUI;
    [SerializeField]
    private float _collisionPenalty;

    private void Awake()
    {
        _afterCollision = false;
        if (_timerManager == null)
        {
            _timerManager = GameObject.Find("TimerManager").GetComponent<TimerManager>();
        }
        if(_lapTimeUI == null)
        {
            _lapTimeUI = GameObject.Find("LapTimeUI").GetComponent<LapTimeUI>();
        }
    }
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && _afterCollision == false)
        {
            _timerManager.Timer += _collisionPenalty;
            _afterCollision = true;
            StartCoroutine(_lapTimeUI.TexTColorChangeOnHit());
        }
    }
}
