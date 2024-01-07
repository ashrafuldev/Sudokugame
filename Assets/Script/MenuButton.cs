using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void LoadScene(string names)
    {
        SceneManager.LoadScene(names);
    }
    public void LoadSceneEasy(string names)
    {
        GameSetting.Instance.SetGameMode(EGameMode.Easy);
        SceneManager.LoadScene(names);
    } 
    public void LoadSceneMedium(string names)
    {
        GameSetting.Instance.SetGameMode(EGameMode.Medium);
        SceneManager.LoadScene(names);
    }
    public void LoadSceneHeard(string names)
    {
        GameSetting.Instance.SetGameMode(EGameMode.Heard);
        SceneManager.LoadScene(names);
    }
    public void LoadSceneVeryHeard(string names)
    {
        GameSetting.Instance.SetGameMode(EGameMode.VeryHeard);
        SceneManager.LoadScene(names);
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
