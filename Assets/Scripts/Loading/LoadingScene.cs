using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
  public string SceneToLoad;//сцена которая будет загружаться
  public GameObject loadScreen;//для хранения экрана загрузки

  public void Load()
  {
    loadScreen.SetActive(true);
    SceneManager.LoadScene(SceneToLoad);
  }
}
