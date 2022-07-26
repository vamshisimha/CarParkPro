using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActualScene : MonoBehaviour
{
    public string ActualSceneOpened;
    private void Start()
    {
        ActualSceneOpened = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("ActualScene", ActualSceneOpened);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu1");
    }

}
    
