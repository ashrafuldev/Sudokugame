
using System;
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
        _gameMode = EGameMode.NotSet;
    }

    public void SetGameMode(EGameMode mode)
    {
        _gameMode = mode;
    }
    public string GetGameMode()
    {
        switch (_gameMode)
        {
            case EGameMode.Easy: return "EASY";
            case EGameMode.Medium: return "MEDIUM";
            case EGameMode.Heard: return "HEARD";
            case EGameMode.VeryHeard: return "VERY_HEARD";
            case EGameMode.NotSet:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        Debug.LogError("Error, Game Level is not SET");
        return " ";
    }
}
public enum EGameMode
{
    NotSet,
    Easy,
    Medium,
    Heard,
    VeryHeard
}


