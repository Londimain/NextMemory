using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasDamage : MonoBehaviour
{
    [SerializeField] private Slider _slider;//для слайдера урона
    [SerializeField] private Vector3 _offset;//для слайдера урона
    [SerializeField] private GameObject textDamage;//для текста урона
    [SerializeField] private Vector3 scaleText;//для текста урона
    private void Update()
    {
        _slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);//для слайдера урона
        textDamage.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + scaleText);//для текста урона
    }
    //для слайдера урона
    public void SetHealtValue(int _currentHealth, int maxHealth)
    {
        _slider.gameObject.SetActive(_currentHealth < maxHealth);
        _slider.value = _currentHealth;
        _slider.maxValue = maxHealth;
    }
    //-------------------
}

