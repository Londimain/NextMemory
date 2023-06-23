//https://www.youtube.com/watch?v=PgMCL5k7sgg
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLose : MonoBehaviour
{
    public float timeStart3 = 3f;
    public float timeStart4 = 2f;
    public Text TextTimerLose;//производится отсщёт
    public GameObject PanelStart;
    public GameObject Level_1;
    public GameObject timeGO;
    
    void Start()
    {
        PanelStart.SetActive(true);
        TextTimerLose.text = timeStart3.ToString();
    }
    void Update()
    {
        if(timeStart3 > 0)
        {
            timeStart3 -= Time.deltaTime;
            TextTimerLose.text = Mathf.Round(timeStart3).ToString();
            
        }
        else
        {
            timeStart3 = 0;
            PanelStart.SetActive(false);
            timeGO.SetActive(true);
            timeStart4 -= Time.deltaTime;
            Mathf.Round(timeStart4).ToString();
        }
        if(timeStart4 > 0)
        {
            timeStart4 -= Time.deltaTime;
            Mathf.Round(timeStart4).ToString();
        }
        else
        {
            timeGO.SetActive(false);
            Level_1.SetActive(true);
            timeStart4 = 0;
        }
    }
}
