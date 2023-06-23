//https://www.youtube.com/watch?v=Hku3Cem7EDg
//https://www.youtube.com/watch?v=C5fd260b2zI
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary; //Библиотека для работы бинарной сериализацией
using System;//для счетчика====

public  class Magazin : MonoBehaviour
{
    public int money;
    public int moneyBons;
    public float msToWait = 5000.0f;//86400000 - это 24ч 5000 - 5сек
    public Text Timer;
    public TextMeshProUGUI moneyText2;
    public Button RewardButton;
    public ulong lastOpenID2;
    public ulong lastOpen;//неиспользую тут но нужен
    //private const string saveKey = "mainSave"; //создал ключ для сохранения данных
    public void  Click()
    {
        money += 50;
        moneyBons += 50;
        lastOpenID2 = ((ulong)DateTime.Now.Ticks);
        //PlayerPrefs.SetString("lastOpen", lastOpen.ToString());
        SaveLoad.Save3(this);
        RewardButton.interactable = false;
        //moneyBons += money;
    }
    public void  ClickDeleteMoney()
    {
        //money = moneyBons;
        moneyBons = 0;
        money = 0;
        //moneyBons = money;
        lastOpenID2 = ((ulong)DateTime.Now.Ticks);
        SaveLoad.Save3(this);
        RewardButton.interactable = false;
    }
    private bool isReady()//
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastOpenID2);
        ulong m = diff / TimeSpan.TicksPerMillisecond;
        float seconleft = (float)(msToWait - m) / 1000.0f;
        if(seconleft < 0)
        {
            Timer.text = "готово";
            return true;
        }
        return false;
    }
    void Start()
    {
        SaveData data2 = SaveLoad.Load2(); //Получение данных
		if(!data2.Equals(null)) //Если данные есть то загружаются и выводятся
		{
		    money = data2.money;
        
            lastOpen = data2.lastOpen;//неиспользую тут но нужен
		}
       
        RewardButton.interactable = false;
        SaveData data3 = SaveLoad.Load3(); //Получение данных
		if(!data3.Equals(null)) //Если данные есть то загружаются и выводятся
		{
            lastOpenID2 = data3.lastOpenID2;

            lastOpen = data3.lastOpen;//неиспользую тут но нужен
            money = data3.money;//неиспользую тут но нужен
		}
    }
    void Update()
    {
        moneyText2.text = money.ToString();
//для счётчика с часами ===========
        if(!RewardButton.IsInteractable())
            {
                if(isReady())
                {
                    RewardButton.interactable = true;
                    Timer.text = "готово";
                    return;
                }
                ulong diff = ((ulong)DateTime.Now.Ticks - lastOpenID2);
                ulong m = diff / TimeSpan.TicksPerMillisecond;
                float seconleft = (float)(msToWait - m) / 1000.0f;
                string t = "";
                t += ((int)seconleft / 3600).ToString() + "ч";
                seconleft -= ((int)seconleft / 3600) * 3600;
                t += ((int)seconleft / 60).ToString("00") + "м";
                t += ((int)seconleft % 60).ToString("00") + "с";
                Timer.text = t;
            }
    }
}