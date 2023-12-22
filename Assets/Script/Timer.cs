using System;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public static Timer Instance;
    private Text _textClock;
    /*private int _hour;
    private int _minute;
    private int _secound;*/
    private float _deltaTime;
    
   private bool _stopClock ;

   private void OnEnable()
   {
       GameEvent.onGameOver += OnGameOver;
   }

   private void OnDisable()
   {
       GameEvent.onGameOver -= OnGameOver;
   }

   private void Awake()
   {
       if (Instance == null)
           Instance = this;
       else Destroy(this);
       
        _textClock = GetComponent<Text>();
        _deltaTime = 0f;
    }

   private void Start()
   {
       _stopClock = true;
   }

   // Update is called once per frame
    void Update()
    {
        if (_stopClock)
        {
            _deltaTime += Time.deltaTime;
            TimeSpan span = TimeSpan.FromSeconds(_deltaTime);
            string hour = LoadingZero(span.Hours);
            string minute = LoadingZero(span.Minutes);
            string second = LoadingZero(span.Seconds);
            _textClock.text = hour + ":" + minute + ":" + second;
        }
    }

      private string LoadingZero(int n)
      {
        return n.ToString().PadLeft(2, '0');
      }

      private void OnGameOver()
      {
          _stopClock = false;
      }

      public Text GetTime()
      {
          return _textClock;
      }
      
      
}
