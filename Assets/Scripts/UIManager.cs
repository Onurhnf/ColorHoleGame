using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    #region Singleton
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }
	#endregion

	[Header("Level Progress UI")]
	//sceneOffset: because you may add other scenes like (Main menu, ...)
	[SerializeField] int sceneOffset;
	[SerializeField] TMP_Text nextLevelText;
	[SerializeField] TMP_Text currentLevelText;
	[SerializeField] Image progressFillImage;

	[Space]
	[SerializeField] TMP_Text levelCompletedText;

	[Space]
	//white fading panel at the start
	[SerializeField] Image fadePanel;

	void Start()
	{
		FadeAtStart();

		//reset progress value
		progressFillImage.fillAmount = 0f;

		SetLevelProgressText();
	}

	void SetLevelProgressText()
	{
		int level = SceneManager.GetActiveScene().buildIndex + sceneOffset;
		currentLevelText.text = level.ToString();
		nextLevelText.text = (level + 1).ToString();
	}

	public void UpdateLevelProgress()
	{
		
	}

	//--------------------------------------
	public void ShowLevelCompletedUI()
	{
		//fade in the text (from 0 to 1) with 0.6 seconds
	}

	public void FadeAtStart()
	{
		//fade out the panel (from 1 to 0) with 1.3 seconds
	}
}
