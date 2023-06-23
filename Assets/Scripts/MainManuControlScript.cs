using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class MainManuControlScript : MonoBehaviour
{
    public List <Button> buttonsList;
	public Button level02Button, level03Button, level04Button, level05Button, level06Button;
	int levelPassed;
	public GameObject Zagruzka;//для карутины перед загрузкой уровня
	public float timeDelay = 5f;//для карутины перед загрузкой уровня 
	//private int money;
	//public TextMeshProUGUI moneyText2;
	public static MainManuControlScript Instance { get; set; }

	// Use this for initialization
void Start () 
{   /*
		SaveData data = SaveLoad.Load2(); //Получение данных
		if(!data.Equals(null)) //Если данные есть то загружаются и выводятся
		{
			money = data.money;
		}
		moneyText2.text = money.ToString();*/
        levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		level02Button.interactable = false;
		level03Button.interactable = false;
		level04Button.interactable = false;
		level05Button.interactable = false;
		level06Button.interactable = false;

switch (levelPassed) 
    {
		case 1:
			level02Button.interactable = true;
			break;
		case 2:
			level02Button.interactable = true;
			level03Button.interactable = true;
			break;
        case 3:
		    level02Button.interactable = true;
			level03Button.interactable = true;
			level04Button.interactable = true;
			break;
        case 4:
		    level02Button.interactable = true;
			level03Button.interactable = true;
			level04Button.interactable = true;
			level05Button.interactable = true;
			break;
		case 5:
		    level02Button.interactable = true;
			level03Button.interactable = true;
			level04Button.interactable = true;
			level05Button.interactable = true;
			level06Button.interactable = true;
			break;
	}
}
public void Continue()
{
	//StartCoroutine(ToggleObjectWithDelay());//для карутины перед загрузкой уровня

	Button lastActiveButton = null;
	for(int i = buttonsList.Count - 1; i >= 0; i--)
	{Button button = buttonsList[i];
	if(button.interactable){button.onClick.Invoke();break;}}
	if(lastActiveButton != null){lastActiveButton.Select();}
}


/*
public void LoadObject(string path)
{
	StartCoroutine(LoadObjectAsync(path));
}
IEnumerator LoadObjectAsync(string path)
	{
        var operation = Resources.LoadAsync<GameObject>(path);
		while(!operation.isDone)
		{
			Continue();
			yield return null;
		}
		Zagruzka = operation.asset as GameObject;
	}
*/	
/*
IEnumerator ToggleObjectWithDelay()//для карутины перед загрузкой уровня
{
    Zagruzka.SetActive(true);
	yield return new WaitForSeconds(timeDelay);
	Zagruzka.SetActive(false);
}
*/



public void Continue2()// метод продолжить - работает но использую 
{
		if (level02Button.interactable){level02Button.GetComponent<Button>().onClick.Invoke();}
		if (level03Button.interactable){level03Button.GetComponent<Button>().onClick.Invoke();}
		if (level04Button.interactable){level04Button.GetComponent<Button>().onClick.Invoke();}
		if (level05Button.interactable){level05Button.GetComponent<Button>().onClick.Invoke();}
		if (level06Button.interactable){level06Button.GetComponent<Button>().onClick.Invoke();}
}
	public void levelToLoad (int level)
	{
        //StartCoroutine(ToggleObjectWithDelay());
		SceneManager.LoadScene (level);
	}

	public void resetPlayerPrefs()
	{
		level02Button.interactable = false;
		level03Button.interactable = false;
		level04Button.interactable = false;
		level05Button.interactable = false;
		level06Button.interactable = false;
		PlayerPrefs.DeleteAll ();
        //PlayerPrefs.DeleteKey("Cena");
	}
}
