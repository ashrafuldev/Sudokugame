
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public delegate void UpgradedSquareNumbers(int number);
    public static event UpgradedSquareNumbers onUpgradedSquareNumbers;
    public static void UpgradedSquareNumberMethod(int number)
    {
        onUpgradedSquareNumbers?.Invoke(number);
    }

    public delegate void SquareSelected(int squareIndex);
    public static event SquareSelected onSquareSelected;
    public static void SquareSelectedMethod(int squareIndex)
    {
        onSquareSelected?.Invoke(squareIndex);
    }

    public delegate void WrongNumber();
    public static event WrongNumber onWrongNumber;
    public static void WrongNumberMethod()
    {
        onWrongNumber?.Invoke();
    }
    public delegate void GameOver();
    public static event GameOver onGameOver;
    public static void OnGameOverMethod()
    {
        onGameOver?.Invoke();
    }

    public delegate void BoardCompleted();
    public static event BoardCompleted onBoardCompleted;

    public static void OnBoardCompletedMethod()
    {
        onBoardCompleted?.Invoke();
    }

    public delegate void CheckBordCompleted();
    public static event CheckBordCompleted onCheckBordCompleted;

    public static void OnCheckBordCompletedMethod()
    {
        onCheckBordCompleted?.Invoke();
    }
}




