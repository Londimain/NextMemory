using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour {

	public static LevelControlScript instance = null;
	GameObject levelSign, gameOverText, youWinText;
	int sceneIndex, levelPassed;

	// Use this for initialization
	void Start () {
		
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		levelSign = GameObject.Find ("LevelNumber");
		gameOverText = GameObject.Find ("GameOverText");
		youWinText = GameObject.Find ("YouWinText");
		gameOverText.gameObject.SetActive (false);
		youWinText.gameObject.SetActive (false);

		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
	}

	public void youWin()
	{
		levelSign.gameObject.SetActive (false);
		youWinText.gameObject.SetActive (true);
		if (sceneIndex == 6)
			Invoke ("loadMainMenu", 0.5f);
		else {
			if (levelPassed < sceneIndex)
				PlayerPrefs.SetInt ("LevelPassed", sceneIndex);
			    Invoke ("loadNextLevel", 0.5f);
		}
	}

	public void youLose()
	{
		levelSign.gameObject.SetActive (false);
		gameOverText.gameObject.SetActive (true);
		Invoke ("loadMainMenu", 0.5f);
	}

	void loadNextLevel()
	{
		SceneManager.LoadScene (sceneIndex + 1);
	}

	void loadMainMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}
/*

	
//добавил - нужно проверить:
    public Button ButtonSave;
    public void LoadDmagHeal()
    {
        ButtonSave.onClick.Invoke();
    }
*/	
}
