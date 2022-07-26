using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPanelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _finishPanelUI;

    public void FinishPanelActivator()
    {
        _finishPanelUI.SetActive(true);
    }

    public void FinishPanelDisactivator()
    {
        _finishPanelUI.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
