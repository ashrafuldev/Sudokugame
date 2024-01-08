using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public GameObject gameOverPopUp;
    public List<GameObject> errorImage;
  
    private int _lives;
    private int _errorNumber;

    private void OnEnable()
    {
        GameEvent.onWrongNumber += WrongNumber;
    }

    private void OnDisable()
    {
        GameEvent.onWrongNumber -= WrongNumber;
    }

    private void Start()
    {
        _lives = errorImage.Count;
        _errorNumber = 0;
    }
    
    private void WrongNumber()
    {
        if (_errorNumber < errorImage.Count)
        {
            errorImage[_errorNumber].SetActive(true);
            _errorNumber++;
           _lives--;
            print(_lives);
        }
        CheckForGameOver();
    }

    private void CheckForGameOver()
    {
        if (_lives > 0) return;
        GameEvent.OnGameOverMethod();
        gameOverPopUp.SetActive(true);
    }
}
