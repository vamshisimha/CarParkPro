using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _uIObjects;
    
    private void OnEnable()
    {
        Time.timeScale = 0;
        foreach (GameObject element in _uIObjects)
        {
            element.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        foreach (GameObject element in _uIObjects)
        {
            element.SetActive(true);
        }
    }
}
