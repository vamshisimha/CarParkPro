using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    public void PausePanelActivator()
    {
        pausePanel.SetActive(true);
    }

    public void PausePanelDisactivator()
    {
        pausePanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
