using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{ 
	[SerializeField] private AudioSource audioSource;

	[SerializeField] private GameObject EscPanel;
	[SerializeField] private GameObject ExplainPanel;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Esc();
		}
	}

	public void Mute(bool value)
	{
		audioSource.mute = !value;
	}

	public void Esc()
	{
		EscPanel.SetActive(!EscPanel.activeSelf);

		if (EscPanel.activeSelf == true)
			Time.timeScale = 0;
		if (EscPanel.activeSelf == false)
			Time.timeScale = 1;
	}

	public void SceneChange(int num)
	{
		SceneManager.LoadScene(num);
	}

	public void Expain()
    {
		ExplainPanel.SetActive(!ExplainPanel.activeSelf);
	}
	
	public void OffExpain()
    {
		ExplainPanel.SetActive(false);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
