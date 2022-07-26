using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
	private string _actualLevel;

	private void Start()
	{
		_actualLevel = SceneManager.GetActiveScene().name;
	}
	public void RestartLevel()
	{
		SceneManager.LoadScene(_actualLevel);
    }
}
