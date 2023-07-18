//https://www.youtube.com/watch?v=zQYIWlUxcG8
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Platform : MonoBehaviour
{
    //для того, что бы игрок мог запрыгивать сквозь платформу - вешается на платформу
    //для того, что бы игрок смог спрыгивать с платформы
    private PlatformEffector2D effector;
    private bool isDownArrow = false;//флаг для отслеживания нажатия кнопки в низ
    private float lastPressTime = 0f;//время последнего нажатия кнопки в низ
    public float deltaTime = 1f;//интервал задержки повторного нажатия на кнопку в низ
    private IEnumerator ResetDownArrow()//для нажатия на кнопку в низ
    {
        yield return new WaitForSeconds(deltaTime);
        isDownArrow = false;
    }
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            effector.rotationalOffset = 0;
        }    
        if(Input.GetKeyDown(KeyCode.DownArrow)&& !isDownArrow && Time.time > lastPressTime + deltaTime)//для нажатия на кнопку в низ)
		{   //в начале происходит задержка с корутиной, а потом нажатие 1 раз
            isDownArrow = true;
            lastPressTime = Time.time;
            StartCoroutine(ResetDownArrow());
            Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, GetComponent<Collider2D>().bounds.size, transform.eulerAngles.z);
            foreach(Collider2D collider in colliders)
			{
				if(collider.gameObject.tag == "Player")
				{
                    Physics2D.IgnoreLayerCollision(1, 0, true);//отключает слои
			        Invoke("IgnoreLayerOff", 0.24f);
				}  
			}
        }       
    }
	void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(1, 0, false);//выключение игнорирование слоёв
    }           
}