
using UnityEngine;

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

    public delegate void BoardCompleted();
    public static event BoardCompleted onBoardCompleted;

    public static void OnBoardCompletedMethod()
    {
        if (onBoardCompleted != null)
            onBoardCompleted();
    }

    public delegate void CheckBordCompleted();
    public static event CheckBordCompleted onCheckBordCompleted;

    public static void OncheckBordCompletedMethod()
    {
        if (onCheckBordCompleted != null)
            onCheckBordCompleted();
    }
}




