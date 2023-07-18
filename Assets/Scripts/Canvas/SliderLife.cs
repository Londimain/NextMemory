using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderLife : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI StatHP;//ссылка на текст урона
    public GameObject targetPers;//ссылка на игрока
    private int direction;//используется для разворота слайдера
    private void Update()
    {
        float playerDirection = Mathf.Sign(targetPers.transform.localScale.x);
        if(playerDirection > 0)
        {
            slider.direction = Slider.Direction.RightToLeft;
        }
        else
        if(playerDirection < 0)
        {
            slider.direction = Slider.Direction.LeftToRight;
        }
    }
}
