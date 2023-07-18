using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Enemy : MonoBehaviour {

	public float life = 250;
//добавил для отображения урона на Enemy
    public Transform TextSpawn;
//-------------------------------------
//добавил
	public Slider hpstat;//для слайдера
	private GameObject canvas;//для слайдера - что бы был плоский
	public GameObject DelPanelDamag;//для удаление папки со слайдером после смерти
	public TextMeshProUGUI StatHP;//текст указывает сколько жизней
	void Start() 
  {
    //hpstat = transform.Find("Canvas/Panel/Slider").gameObject.GetComponent<Slider>();
	canvas = transform.Find("Canvas").gameObject;
  }
  void Update()
  {
	if(canvas.transform.rotation != Camera.main.transform.rotation)
	{
		canvas.transform.rotation = Camera.main.transform.rotation;
	}
	StatHP.text = life.ToString("0");// добавил отображение жизней над головой
	hpstat.value = life;
	if(life<0){life=0;}//когда жизни заканчиваются - что бы не писалось <0
  }
//-------

	private bool isPlat;
	private bool isObstacle;
	private Transform fallCheck;
	private Transform wallCheck;
	public LayerMask turnLayerMask;
	private Rigidbody2D rb;

	private bool facingRight = true;
	
	public float speed = 5f;

	public bool isInvincible = false;
	private bool isHitted = false;

	void Awake () {
		fallCheck = transform.Find("FallCheck");
		wallCheck = transform.Find("WallCheck");
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (life <= 0) {
			DelPanelDamag.SetActive(false);//для удаления папки со слайдером после смерти
			//----------------------
			transform.GetComponent<Animator>().SetBool("IsDead", true);
			StartCoroutine(DestroyEnemy());
		}
		isPlat = Physics2D.OverlapCircle(fallCheck.position, .2f, 1 << LayerMask.NameToLayer("Default"));
		isObstacle = Physics2D.OverlapCircle(wallCheck.position, .2f, turnLayerMask);
		if (!isHitted && life > 0 && Mathf.Abs(rb.velocity.y) < 0.5f)
		{
			if (isPlat && !isObstacle && !isHitted)
			{
				if (facingRight)
				{
					rb.velocity = new Vector2(-speed, rb.velocity.y);
				}
				else
				{
					rb.velocity = new Vector2(speed, rb.velocity.y);
				}
			}
			else
			{
				Flip();
			}
		}
	}

	void Flip (){
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
        //далее для того что бы над головой выравнивался текст дамага и количество жизней
		if(theScale.x != 1)
		{
           StatHP.transform.Rotate(0f,-180f,0f);
		   TextSpawn.transform.Rotate(0f,-180f,0f);
		}
		if(theScale.x == 1)
		{
           StatHP.transform.Rotate(0f,180f,0f);
		   TextSpawn.transform.Rotate(0f,180f,0f);
		}
	}
//, int _currentHealth, int maxHealth добавил
//_healthBar.SetHealtValue(_currentHealth, maxHealth); добавил
GameObject go;
	public void ApplyDamage(float damage) {
		if (!isInvincible) 
		{
			float direction = damage / Mathf.Abs(damage);
			//damage = Mathf.Abs(damage);
			damage = Random.Range(10f, 50f);//Изменил на рандомный приём урона на Enemy(врага)
			transform.GetComponent<Animator>().SetBool("Hit", true);
			life -= damage;
			rb.velocity = Vector2.zero;
			rb.AddForce(new Vector2(direction * 500f, 100f));
			hpstat.value = life;//добавил для отображения жизней в слайдере

           if(damage > 0)
		{
			
		}
			
        //добавил для отображения урона на Enemy, но было /2
            float textSize = damage * 2;
			//GameObject go = Instantiate
            go = Instantiate(Resources.Load("DamageAnimationText"), TextSpawn.localPosition, Quaternion.identity) as GameObject;
            go.transform.SetParent(TextSpawn.transform, false);
            go.GetComponent<TMPro.TextMeshProUGUI>().SetText(damage.ToString("F0"));
            go.name = damage.ToString("F0");
            //go.GetComponent<TMPro.TextMeshPro>();
			go.GetComponent<TMPro.TextMeshProUGUI>().fontSize = textSize;
            Destroy(go, 0.7f);
        //-----------------------------
			StartCoroutine(HitTime());
		}
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && life > 0)
		{
			//2f заменил на Random.Range(1f, 5f) для нанесение рандомного урона на игрока
			collision.gameObject.GetComponent<CharacterController2D>().ApplyDamage(Random.Range(1f, 5f), transform.position);
			
		}
	}

	IEnumerator HitTime()
	{
		isHitted = true;
		isInvincible = true;
		yield return new WaitForSeconds(0.1f);
		isHitted = false;
		isInvincible = false;
	}

	IEnumerator DestroyEnemy()
	{
		Destroy(StatHP);//добавил что бы удалялся текст домага
		hpstat.interactable = false;
		CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
		capsule.size = new Vector2(1f, 0.25f);
		capsule.offset = new Vector2(0f, -0.8f);
		capsule.direction = CapsuleDirection2D.Horizontal;
		yield return new WaitForSeconds(0.25f);
		rb.velocity = new Vector2(0, rb.velocity.y);
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}
}
