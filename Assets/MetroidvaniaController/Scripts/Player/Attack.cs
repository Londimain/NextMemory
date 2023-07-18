using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	//поменял public float dmgValue = 4;// для рандомного урона поменял
	private float dmgValue;
	public GameObject throwableObject;
	public Transform attackCheck;
	private Rigidbody2D m_Rigidbody2D;
	public Animator animator;
	public bool canAttack = true;
	public bool isTimeToCheck = false;

	public GameObject cam;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.X) && canAttack)
		{
			Knopa2();
		}

		if (Input.GetKeyDown(KeyCode.V))
		{
			Knopa4();
		}
	}

	IEnumerator AttackCooldown()
	{
		yield return new WaitForSeconds(0.25f);
		canAttack = true;
	}

	public void DoDashDamage()
	{
		//поменял для рандомного урона
		//dmgValue = Mathf.Abs(dmgValue);
		dmgValue = Random.Range(1f, 5f);//урон при мече для врага
		Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
		for (int i = 0; i < collidersEnemies.Length; i++)
		{
			if (collidersEnemies[i].gameObject.tag == "Enemy")
			{
				if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
				{
					dmgValue = -dmgValue;
				}
				collidersEnemies[i].gameObject.SendMessage("ApplyDamage", dmgValue);
				cam.GetComponent<CameraFollow>().ShakeCamera();
			}
		}
	}
public void Knopa2()//Для управление кнопками
{
	canAttack = false;
	animator.SetBool("IsAttacking", true);
	StartCoroutine(AttackCooldown());
}
public void Knopa4()
{
    animator.SetBool("Piu", true);//добавил анимацию выстрела
	GameObject throwableWeapon = Instantiate(throwableObject, transform.position + new Vector3(transform.localScale.x * 0.5f,-0.2f), Quaternion.identity) as GameObject; 
	Vector2 direction = new Vector2(transform.localScale.x, 0);
	throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction; 
	throwableWeapon.name = "ThrowableWeapon";
}
}
