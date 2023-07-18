using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderDamage : MonoBehaviour
{
    [SerializeField] private Slider _slider;//для слайдера урона
    [SerializeField] private Vector3 _offset;//для слайдера урона
    void Start()//добавил
    {
      //_slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);//для слайдера урона
    }

    private void LiteUpdate()
    {
        _slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);//для слайдера урона
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
