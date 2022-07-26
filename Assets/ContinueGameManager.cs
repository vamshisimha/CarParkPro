using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGameManager : MonoBehaviour
{
    [SerializeField]
    private string SceeneToContinue;

    private void Start()
    {
        SceeneToContinue = PlayerPrefs.GetString("ActualScene");
    }

    public void ContinueButton()
    {
        if (SceeneToContinue.Length > 2 )
        {
            SceneManager.LoadScene(SceeneToContinue);
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
