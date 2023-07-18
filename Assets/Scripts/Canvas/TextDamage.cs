using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDamage : MonoBehaviour
{
    [SerializeField] private GameObject textDamage;//для текста урона
    [SerializeField] private Vector3 scaleText;//для текста урона
    private void Start()
    {
        textDamage.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + scaleText);//для текста урона
    
    }
    private void Update()
    {
        //textDamage.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + scaleText);//для текста урона
    }    
}
