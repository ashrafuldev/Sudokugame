using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lives : MonoBehaviour
{
    public GameObject gameOverPopUp;
    public List<GameObject> errorImage;
  
    private int _lives;
    private int _errorNumber;

    private void OnEnable()
    {
        GameEvent.onWorngNumber += WrongNumber;
    }

    private void OnDisable()
    {
        GameEvent.onWorngNumber -= WrongNumber;
    }

    void Start()
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
        if (_lives <= 0)
        {
            GameEvent.OnGameOverMethod();
            gameOverPopUp.SetActive(true);
        }
    }
    
}
