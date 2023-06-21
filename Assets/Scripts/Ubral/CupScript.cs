using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour
{
	public string Player; // публичная переменная (сторока), т.е. кто будет входить в триггер
    public GameObject Players;
	void OnTriggerEnter2D(Collider2D col)// триггер, реагирует при взаимодействии с ним (при входе игрока в триггер)
	{// если в коллайдер попал наш игрок (а именно public string player). и собрали определенное количество монет
	 //Т.Е. игрок достиг итоговой точки данного уровня и уничтожается
		if (col.tag == Player) 
		//if (col.tag == Player && money_player.money >=3) 
		{
		
		Destroy(Players);
		LevelControlScript.instance.youWin ();
		}
	}
}
