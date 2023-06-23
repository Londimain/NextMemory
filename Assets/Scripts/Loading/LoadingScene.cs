//неиспользую в проекте !!!!!!!!!!!!!!!!!!!!!!!!!!
//неиспользую в проекте !!!!!!!!!!!!!!!!!!!!!!!!!!
//неиспользую в проекте !!!!!!!!!!!!!!!!!!!!!!!!!!
//неиспользую в проекте !!!!!!!!!!!!!!!!!!!!!!!!!!
//неиспользую в проекте !!!!!!!!!!!!!!!!!!!!!!!!!!
// НО РАБОТАЕТ
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScene : MonoBehaviour
{
  public string SceneToLoad;//слайдер.. сцена которая будет загружаться
  public GameObject loadScreen;//слайдер..для хранения экрана загрузки
  public Slider bar;//слайдер

  public void Load()//слайдер
  {
    loadScreen.SetActive(true);
    //SceneManager.LoadScene(SceneToLoad);
    StartCoroutine(LoadAsync());
  }
  IEnumerator LoadAsync()//слайдер
  {
    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneToLoad);
    while(!asyncLoad.isDone)
    {
        bar.value = asyncLoad.progress;
        yield return null;
    }
  }
}
