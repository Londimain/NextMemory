using UnityEngine;
using System.IO; //Библиотек для работы с файлами
using System.Runtime.Serialization.Formatters.Binary; //Библиотека для работы бинарной сериализацией

public static class SaveLoad //Создание статичного класса позволит использовать методы без объявления его экземпляров
{
	private static string path = Application.persistentDataPath + "/r.dat"; //Путь к сохранению. Вы можете использовать любое расширение
	//"/gamesave.skillbox"
	
    private static BinaryFormatter formatter = new BinaryFormatter(); //Создание сериализатора
  
	public static void Save(PlayerMovement character) //Метод для сохранения
	{
		FileStream fs = new FileStream (path, FileMode.Create); //Создание файлового потока
		SaveData data = new SaveData(character); //Получение данных
		formatter.Serialize(fs, data); //Сериализация данных
		fs.Close(); //Закрытие потока
	}

	public static SaveData Load() //Метод загрузки
	{
		if(File.Exists(path)) { //Проверка существования файла сохранения
			FileStream fs = new FileStream(path, FileMode.Open); //Открытие потока
			SaveData data = formatter.Deserialize(fs) as SaveData; //Получение данных
			fs.Close(); //Закрытие потока
			return data; //Возвращение данных
		} 
		else 
		{
			return null; //Если файл не существует, будет возвращено null
		}
	}

public static void Save2(MoneyManager character2) //Метод для сохранения
	{
		FileStream fs = new FileStream (path, FileMode.Create); //Создание файлового потока
		SaveData data2 = new SaveData(character2); //Получение данных
		formatter.Serialize(fs, data2); //Сериализация данных
		fs.Close(); //Закрытие потока
	}

	public static SaveData Load2() //Метод загрузки
	{
		if(File.Exists(path)) { //Проверка существования файла сохранения
			FileStream fs = new FileStream(path, FileMode.Open); //Открытие потока
			SaveData data2 = formatter.Deserialize(fs) as SaveData; //Получение данных
			fs.Close(); //Закрытие потока
			return data2; //Возвращение данных
		} 
		else 
		{
			return null; //Если файл не существует, будет возвращено null
		}
	}

	public static void Save3(Magazin character3) //Метод для сохранения
	{
		FileStream fs = new FileStream (path, FileMode.Create); //Создание файлового потока
		SaveData data3 = new SaveData(character3); //Получение данных
		formatter.Serialize(fs, data3); //Сериализация данных
		fs.Close(); //Закрытие потока
	}

	public static SaveData Load3() //Метод загрузки
	{
		if(File.Exists(path)) { //Проверка существования файла сохранения
			FileStream fs = new FileStream(path, FileMode.Open); //Открытие потока
			SaveData data3 = formatter.Deserialize(fs) as SaveData; //Получение данных
			fs.Close(); //Закрытие потока
			return data3; //Возвращение данных
		} 
		else 
		{
			return null; //Если файл не существует, будет возвращено null
		}
	}








/*
//--------------------------------------------------------------------
	//добавил - нужно проверить:
	private static string pathAtt = Application.persistentDataPath + "/Att.dat";
	public static void Save4(Attack character4)
	{
		FileStream Att = new FileStream (pathAtt, FileMode.Create);
		SaveData data4 = new SaveData(character4); 
		formatter.Serialize(Att, data4); 
		Att.Close();
	}
	public static SaveData Load4()
	{
		if(File.Exists(pathAtt))
		{ 
			FileStream Att = new FileStream(pathAtt, FileMode.Open);
			SaveData data4 = formatter.Deserialize(Att) as SaveData;
			Att.Close();
			return data4;
		} 
		else 
		{
			return null;
		}
	}
*/
}