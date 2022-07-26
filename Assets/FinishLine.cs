using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    private TimerManager _timerManager;
    [SerializeField]
    private FinishPanelManager _finishPanelManager;
    [SerializeField]
    private CheckpointOnTrigger _checkpointOnTrigger;

    private void Awake()
    {
        if(_timerManager == null)
        {
            _timerManager = GameObject.Find("TimerManager").GetComponent<TimerManager>();
        }
        if(_finishPanelManager == null)
        {
            _finishPanelManager = GameObject.Find("FinishPanelManager").GetComponent<FinishPanelManager>();
        }
        if(_checkpointOnTrigger == null)
        {
            _checkpointOnTrigger = GameObject.Find("Checkpoint").GetComponent<CheckpointOnTrigger>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _timerManager.IsStarted = true;
        }
        if(other.gameObject.tag == "Player" && _timerManager.IsStarted == true && _checkpointOnTrigger.CheckpointReached == true)
        {
            _timerManager.Finished();
            _finishPanelManager.FinishPanelActivator();
        }
    }
}
