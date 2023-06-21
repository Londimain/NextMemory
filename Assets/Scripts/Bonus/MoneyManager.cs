//https://www.youtube.com/watch?v=Hku3Cem7EDg
//https://www.youtube.com/watch?v=C5fd260b2zI
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary; //Библиотека для работы бинарной сериализацией
using System;//для счетчика====

public  class MoneyManager : MonoBehaviour
{
    public int money;
    public int moneySBOR;
    //public int SaVeS;
    public int Apple;//яблоки
    public float time;
    private float timeStart;
    public GameObject Players;//для уничтожения игрока после входа в тригер
    //public TextMeshProUGUI moneyText;
    public TextMeshProUGUI AppleText;
    public TextMeshProUGUI moneyTextSBOR;
    public Button Bonus;
    public ulong lastOpenID2;//неиспользую тут но нужен
    public int moneyBons;//неиспользую тут но нужен
/*
//-----------------------------------------не знаю как это работает - но сказали можно задействовать
private readonly List<string> Respawn = new List<string>();

void OnTriggerStay2D(Collider2D collider)
{
    //Add some kind of filter or safety check if needed
    Respawn.Add(collider.tag);

}
//------------------------------------------
*/

//для счётчика=================
    public float msToWait = 5000.0f;//86400000 - это 24ч 5000 - 5сек
    public Text Timer;
    public Button RewardButton;
    public ulong lastOpen;
    public void  Click()
    {
        moneySBOR += 50;
        money += 50;
        lastOpen = ((ulong)DateTime.Now.Ticks);
        //PlayerPrefs.SetString("lastOpen", lastOpen.ToString());
        //SaveLoad.Save2(this);//сохранил данные переменных
        RewardButton.interactable = false;
    }
    private bool isReady()//
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float seconleft = (float)(msToWait - m) / 1000.0f;
        if(seconleft < 0)
        {
            Timer.text = "готово";
            return true;
        }
        return false;
    }
//===========================
    void Start()
    {

        /*
        //для счётчика с часами =======
        //RewardButton = GetComponent<Button>();
        //загрузка времени
        if (PlayerPrefs.HasKey("lastOpen"))
        {
        lastOpen = ulong.Parse(PlayerPrefs.GetString("lastOpen"));
        //Timer = GetComponentInChildren<Text>(); 
        }
        else
        Debug.Log("The key" + lastOpen + " does mnot exist");
        
        if(!isReady())    
        {
            RewardButton.interactable = false;
        }*/
        //========================загрузку сделал по другому

        timeStart = time;
        SaveData data2 = SaveLoad.Load2(); //Получение данных
		if(!data2.Equals(null)) //Если данные есть то загружаются и выводятся
		{
		    money = data2.money;
            lastOpen = data2.lastOpen;

		    lastOpenID2 = data2.lastOpenID2;//неиспользую тут но нужен
		}
        Bonus.interactable = false;//кнопка Bonus при старте неактивна
        RewardButton.interactable = false;
    }
    void Update()
    {
//для счётчика с часами ===========
        if(!RewardButton.IsInteractable())
            {
                if(isReady())
                {
                    RewardButton.interactable = true;
                    Timer.text = "готово";
                    return;
                }
                
                ulong diff = ((ulong)DateTime.Now.Ticks - lastOpen);
                ulong m = diff / TimeSpan.TicksPerMillisecond;
                float seconleft = (float)(msToWait - m) / 1000.0f;
                string t = "";
                t += ((int)seconleft / 3600).ToString() + "ч";
                seconleft -= ((int)seconleft / 3600) * 3600;
                t += ((int)seconleft / 60).ToString("00") + "м";
                t += ((int)seconleft % 60).ToString("00") + "с";
                Timer.text = t;
            }
//таймер дробавления без счётчика ================

        time -= Time.deltaTime;//таймер авто добавления монет
        moneyTextSBOR.text = "" + moneySBOR;
        if (time <=0)
        {
            //moneySBOR += 5;
            //money += 5;
            Bonus.interactable = true;
            time += timeStart;
        
        if (time >= -1)
        {
            time = 0;
        }
        }    
    }
    public void OnTriggerStay2D(Collider2D other)// триггер, реагирует при взаимодействии с ним (при входе игрока в триггер)
{
       //if (other.CompareTag("Scull"))//бывший варриант
        if (other.gameObject.tag == "Coin")
        {
            //money += Random.Range(10,100);//рандомное добавление
            moneySBOR += 1;//добавление монет
            money += 1;//добавление монет в фоне
            //moneyText.text = money.ToString();//прописывается в текст
            moneyTextSBOR.text = moneySBOR.ToString();//прописывается в текст
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Rondom")
        {
            moneySBOR += UnityEngine.Random.Range(10,20);//рандомное добавление*/ 
            //UnityEngine.Random.Range(10,20); - Random.Range(10,20); 
            Destroy(other.gameObject);
        }  
        if (other.gameObject.tag == "Apple")
        {
            Apple +=20;
            AppleText.text = Apple.ToString();
            Destroy(other.gameObject); 
        }
        if (other.gameObject.tag == "Finish")
        {
        SaveLoad.Save2(this);//сохранил данные переменных
        Players.gameObject.SetActive (false);//Если грок достиг итоговой точки данного уровня то он уничтожается
        //Destroy(Players);//Если грок достиг итоговой точки данного уровня то он уничтожается
		LevelControlScript.instance.youWin ();//переходит на следующую сцену
        //if (col.tag == Player && money_player.money >=3) //условие (что бы перейти нужно набрать 3 шт)
        }  
        if (other.gameObject.tag == "Scull")
        {
        Players.gameObject.SetActive (false);
		LevelControlScript.instance.youLose ();
        }
        /*if(GameObject.FindWithTag("Respawn") == null){}*/
}
    public void MoneyButton()
    {
        Bonus.interactable = false;
        moneySBOR += 100;
        money += 100;
        if (time == 0)
        {
           time += timeStart;
        }
    }
}