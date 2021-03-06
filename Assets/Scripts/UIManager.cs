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
	
	public bool showWinText;
	[SerializeField] TMP_Text nextLevelText;
	[SerializeField] TMP_Text currentLevelText;
	[SerializeField] Image progressFillImage;

	[Space]
	public TMP_Text levelCompletedText;


	

	void Start()
	{
		

		progressFillImage.fillAmount = 0f;
		
		levelCompletedText.gameObject.GetComponent<TextMeshProUGUI>().enabled = false;

		SetLevelProgressText();
	}

	void SetLevelProgressText()
	{
		int level = SceneManager.GetActiveScene().buildIndex+1;
		currentLevelText.text = level.ToString();
		nextLevelText.text = (level + 1).ToString();
	}

	public void UpdateLevelProgress()
	{
		float fill = 1f - ((float)LevelManager.Instance.objectsInScene / LevelManager.Instance.totalObjects);
		progressFillImage.fillAmount = fill;
	}

	public void ShowLevelCompletedUI()
	{


		levelCompletedText.GetComponent<MeshRenderer>().enabled = showWinText;
	}


}
