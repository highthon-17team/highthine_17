using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
	private AudioSource audioSource;

	[SerializeField] private GameObject EscPanel;

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
	}

	public void SceneChange(int num)
	{
		SceneManager.LoadScene(num);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
