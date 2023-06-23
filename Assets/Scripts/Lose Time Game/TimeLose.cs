//https://www.youtube.com/watch?v=PgMCL5k7sgg
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLose : MonoBehaviour
{
    public float timeStart3 = 3f;//таймер при запуске сцены
    public float timeStart4 = 2f;//таймер срабатывает после timeStart3
    public float timeStart5 = 10f;//таймер нахождения на уровне
    public Text TextTimerStart;//производится отсчёт
    public Text TextTimerLose;//производится отсчёт до окончания выданного времени на прохождение
    public GameObject PanelStart;//панель для TextTimerStart, timeStart3
    public GameObject Level_1;//уровень в котором игра
    public GameObject PanelTimeGo;//оповещает о том что можно играть прогружая уровень
    public GameObject PanelLose;//панель будет выводиться после окончания выданого времени на прохождение
    
    void Start()
    {
        PanelStart.SetActive(true);
        TextTimerStart.text = timeStart3.ToString();
        TextTimerStart.text = timeStart5.ToString();
    }
    void Update()
    {
    {   if(timeStart3 > 0)
        {
            timeStart3 -= Time.deltaTime;
            TextTimerStart.text = Mathf.Round(timeStart3).ToString();     
        }
        else
        {
            timeStart3 = 0;
            PanelStart.SetActive(false);
            PanelTimeGo.SetActive(true);
            timeStart4 -= Time.deltaTime;
            Mathf.Round(timeStart4).ToString();
        if(timeStart4 > 0)
        {
            timeStart4 -= Time.deltaTime;
            Mathf.Round(timeStart4).ToString();
        }
        else
        {
            PanelTimeGo.SetActive(false);
            Level_1.SetActive(true);
            timeStart4 = 0;
        if(timeStart5 > 0)
        {
            timeStart5 -= Time.deltaTime;
            TextTimerLose.text = Mathf.Round(timeStart5).ToString();
        }
        else
        {
            PanelLose.SetActive(true);
            timeStart5 = 0;
            Level_1.SetActive(false);
        }
        }
        }
    }
    }
}
