using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadSceneEasy(string name)
    {
        GameSetting.Instance.SetGameMode(EGameMode.EASY);
        SceneManager.LoadScene(name);
    } 
    public void LoadSceneMedium(string name)
    {
        GameSetting.Instance.SetGameMode(EGameMode.MEDIUM);
        SceneManager.LoadScene(name);
    }
    public void LoadSceneHeard(string name)
    {
        GameSetting.Instance.SetGameMode(EGameMode.HEARD);
        SceneManager.LoadScene(name);
    }
    public void LoadSceneVeryHeard(string name)
    {
        GameSetting.Instance.SetGameMode(EGameMode.VERY_HEARD);
        SceneManager.LoadScene(name);
    }

    public void ActiveObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void DeActiveObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
