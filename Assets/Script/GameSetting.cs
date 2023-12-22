
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public static GameSetting Instance;
    private EGameMode _gameMode;
    
    private void Awake()
    {
        if (Instance == null)
        {
            //DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(this);
    }
    private void Start()
    {
        _gameMode = EGameMode.NOT_SET;
    }

    public void SetGameMode(EGameMode mode)
    {
        _gameMode = mode;
    }

    /*public void SetGameMode(string mode)
    {
        if(mode == "EASY") SetGameMode(EGameMode.EASY);
        else if(mode == "MEDIUM") SetGameMode(EGameMode.MEDIUM);
        else if(mode == "HEARD") SetGameMode(EGameMode.HEARD);
        else if(mode == "VERY_HEARD") SetGameMode(EGameMode.VERY_HEARD);
        else SetGameMode(EGameMode.NOT_SET);
    }*/

    public string GetGameMode()
    {
        switch (_gameMode)
        {
            case EGameMode.EASY: return "EASY";
            case EGameMode.MEDIUM: return "MEDIUM";
            case EGameMode.HEARD: return "HEARD";
            case EGameMode.VERY_HEARD: return "VERY_HEARD";
        }
        Debug.LogError("Error, Game Level is not SET");
        return " ";
    }
}
public enum EGameMode
{
    NOT_SET,
    EASY,
    MEDIUM,
    HEARD,
    VERY_HEARD
}


