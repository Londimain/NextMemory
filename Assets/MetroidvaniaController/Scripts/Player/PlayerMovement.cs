using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
    public int health = 5;
	public float runSpeed = 40f;
    public float normalSpeed = 30f;//для управления кнопками
	float horizontalMove = 0f;
	bool jump = false;
	bool dash = false;
	void Start()
	{
		SaveData data = SaveLoad.Load(); //Получение данных
		if(!data.Equals(null)) //Если данные есть то загружаются и выводятся
		{
		    health = data.health;
		}
		horizontalMove = 0f;//добавил 3 шт что бы управлять в лево и в право
	}

	//bool dashAxis = false;
	
	// Update is called once per frame
	void Update () {

		//horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;//отключил управление, что бы управлять кнопками

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetKeyDown(KeyCode.Z))
		{
			Knopa1();
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			Knopa3();
		}

		/*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
		{
			if (dashAxis == false)
			{
				dashAxis = true;
				dash = true;
			}
		}
		else
		{
			dashAxis = false;
		}
		*/
	}

	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash);
		jump = false;
		dash = false;
	}
//добавил 3 шт что бы управлять в лево и в право
public void OnLeftButtonDown()
	{
		if(horizontalMove >= 0f)
		{
            horizontalMove = -normalSpeed;
		}
	}
public void OnRightButtonDown()
	{
		if(horizontalMove <= 0f)
		{
			horizontalMove = normalSpeed;
		}
	}
public void OnButtonUp()
    {
    	horizontalMove = 0f;
    }
public void Knopa1()//для прыжка
{
	jump = true;
}
public void Knopa3()//для рывка
{
	dash = true;
}
//----------------------- Реализация нажатия на кнопку в низ - что бы спрыгивал с платформы
    //private bool isDownArrow = false;//флаг для отслеживания нажатия кнопки в низ
    private float lastPressTime = 0f;//время последнего нажатия кнопки в низ
    public float deltaTime = 1f;//интервал задержки повторного нажатия на кнопку в низ
    private IEnumerator ResetDownArrow()//для нажатия на кнопку в низ
    {
        yield return new WaitForSeconds(deltaTime);
        isDownArrow = false;
    }
    public PlayerMovement buttonScript;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isOnObject = true;
	    buttonScript.vnizGo(collision, isOnObject);
    }
public void vnizGo(Collision2D collision, bool isOnObject = false)
{
    if(collision.gameObject.GetComponent<PlatformEffector2D>() != null)
	{
		isOnObject = true;
	}
    if(collision.gameObject.GetComponent<PlatformEffector2D>() != null)
	{
		isOnObject = false;
	}
    if(isOnObject)
	{
		//Debug.Log("False");
		verh2 = false;
	}
	else
    {
        verh2 = true; 
	}
}
	void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(1, 0, false);//выключение игнорирование слоёв
		verh2 = false;
    } 
bool verh2 = false;
private bool isDownArrow = false;//флаг для отслеживания нажатия кнопки в низ
public void VNIZ(bool verh = false)
{
	if(verh2 == false)
	{
        //Debug.Log("NoPlatform");
	}
	if(verh2 == true)
	{
		if(!isDownArrow && Time.time > lastPressTime + deltaTime)
		{
		isDownArrow = true;
        lastPressTime = Time.time;
        StartCoroutine(ResetDownArrow());
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, GetComponent<Collider2D>().bounds.size, transform.eulerAngles.z);
        foreach(Collider2D collider in colliders)
		{
			if(collider.gameObject.tag == "Player")
			{
                Physics2D.IgnoreLayerCollision(1, 0, true);
			    Invoke("IgnoreLayerOff", 0.24f);
			}       
		}
		}
	}
}
}
