using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallordOneHitColl : MonoBehaviour
{
    [SerializeField]
    private PauseManager _pauseManager;

    private void Awake()
    {
        if(_pauseManager == null)
        {
            _pauseManager = GameObject.Find("PauseManager").GetComponent<PauseManager>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Player" /*& collision.gameObject.tag == "WheelCollider" */)
        {
            _pauseManager.PausePanelActivator();
        }
    }
}
