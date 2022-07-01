using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	#region Singleton

	public static LevelManager Instance;

	

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	#endregion

	[SerializeField] ParticleSystem winFx;

	[Space]
	[HideInInspector] public int objectsInScene;
	[HideInInspector] public int totalObjects;

	[SerializeField] Transform objectsParent;



	void Start()
	{
		CountObjects();
	}

	void CountObjects()
	{
		
		totalObjects = objectsParent.childCount;
		objectsInScene = totalObjects;
	}

	public void PlayWinFx()
	{
		winFx.Play();
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		UIManager.Instance.showWinText = false;
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
