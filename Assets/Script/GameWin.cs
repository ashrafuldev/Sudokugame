
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameWin : MonoBehaviour
{
    public GameObject winPoUp;
    [SerializeField] private Text timeText;

    private void OnEnable()
    {
        GameEvent.onBoardCompleted += OnBordCompleted;
    }

    private void OnDisable()
    {
        GameEvent.onBoardCompleted -= OnBordCompleted;
    }

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = Timer.Instance.GetTime().text;
        winPoUp.SetActive(false);
    }

    private void OnBordCompleted()
    {
        timeText.text = Timer.Instance.GetTime().text;
        winPoUp.SetActive(true);
    }
    
}
