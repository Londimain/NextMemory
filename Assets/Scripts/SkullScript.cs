using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkullScript : MonoBehaviour
{
	public string Player;
    public GameObject Players;
	void OnTriggerEnter2D(Collider2D col)
	{
		//if (col.gameObject.tag == "Player")
		if (col.tag == Player) 
	    {
		Players.gameObject.SetActive (false);
		LevelControlScript.instance.youLose ();
        //Destroy(Players);
		//PlayerPrefs.DeleteKey("coins");
	    }
	}
}