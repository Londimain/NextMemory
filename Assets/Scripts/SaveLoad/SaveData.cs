[System.Serializable] //Обязательно нужно указать, что класс должен сериализоваться
public class SaveData 
{
	//Создание полей с игровыми параметрами
	public float currHP;
	public float HP;
	public float currMP;
	public float MP;
	public float currXP;
	public float XP;
	public int level;
    public int currentAmmo;
    public int allAmmo;
    public int health;
	public int money;
	public ulong lastOpen;//таймер
	public ulong lastOpenID2;//таймер в магазине
	public float[] position; //В Unity позиция игрока записана с помощью класса Vector3, но его нельзя сериализовать. Чтобы обойти эту проблему, данные о позиции будут помещены в массив типа float.
    
	public SaveData(PlayerMovement character) //Конструктор класса
	{
		//Получение данных, которые нужно сохранить
		//HP = character.HP;
		//currHP = character.currHP;
		//MP = character.MP;
		//currMP = character.currMP;
		//XP = character.XP;
		//currXP = character.currXP;
		//level = character.level;
        //currentAmmo = character.currentAmmo;
        //allAmmo = character.allAmmo;
        health = character.health;

		position = new float[3] //Получение позиции
		{
			character.transform.position.x,
			character.transform.position.y,
			character.transform.position.z
		};
	}
	public SaveData(MoneyManager character2) //Конструктор класса
	{
		money = character2.money;
		lastOpen = character2.lastOpen;
        
		lastOpenID2 = character2.lastOpenID2;
	}
    
	public SaveData(Magazin character3) //Конструктор класса
	{
		lastOpenID2 = character3.lastOpenID2;

        money = character3.money;
		lastOpen = character3.lastOpen;
	}
     
}


