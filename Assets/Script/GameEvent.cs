
using UnityEngine;
using UnityEngine.UI;

public class GameEvent : MonoBehaviour
{
    public delegate void UpgrateSqureNumber(int number);
    public static event UpgrateSqureNumber onUpgrateSqureNumber;
    public static void UpdateSqureNumberMethod(int number)
    {
            if (onUpgrateSqureNumber != null)
                onUpgrateSqureNumber(number);
    }

    public delegate void SqureSelected(int squreIndex);
    public static event SqureSelected onSqureSelected;
    public static void SqureSelectMehtod(int squreindex)
    {
        if (onSqureSelected != null)
            onSqureSelected(squreindex);
    }

    public delegate void WrongNumber();
    public static event WrongNumber onWorngNumber;
    public static void WrongNumberMethod()
    {
        if (onWorngNumber != null)
            onWorngNumber();
    }
    
    public delegate void GameOver();
    public static event GameOver onGameOver;
    public static void OnGameOverMethod()
    {
        if (onGameOver != null)
            onGameOver();
    }
}




