using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GridSqure : Selectable, IPointerClickHandler, ISubmitHandler
{
    public GameObject number_text;
    private int _number;
    private bool _isSelected = false;
    private int _squreIndex = -1;
    private int _currentNumber;
    private bool _hasDefultValue;
   // public bool IsSelecter => _isSelected;

    public bool IsCorrectNumberSet()
    {
        return _number == _currentNumber;
    }
    protected override void OnEnable()
    {
        GameEvent.onUpgrateSqureNumber += OnSetNumber;
        GameEvent.onSqureSelected += OnSqureSelect;
    }

    protected override void OnDisable()
    {
        GameEvent.onUpgrateSqureNumber -= OnSetNumber;
        GameEvent.onSqureSelected += OnSqureSelect;
    }
    
    private void OnSetNumber(int number)
    {
        if (_isSelected && _hasDefultValue == false)  
        {
            SetNumber(number);
            if (_number != _currentNumber)
            {
                var color = this.colors;
                color.normalColor = Color.red;
                this.colors = color;
                GameEvent.WrongNumberMethod();   // RED Crose image active for live dicrese 
            }
            else
            {
               // _hasDefultValue = true;
                var color = this.colors;
                color.normalColor = Color.white;
                this.colors = color;
            }
            
            GameEvent.OncheckBordCompletedMethod();
        }
    }

    private void OnSqureSelect( int squreIndexed)
    {
        if (_squreIndex != squreIndexed)
        {
            _isSelected = false;
        }
    }
    
    protected override void Start()
    {
        _isSelected = false;
    }
    
    public void SetNumber(int number)
    {
        _number = number;
        DisplayText();
    }
    
    public void SetSqureIndex(int index)
    {
        _squreIndex = index;
    }

    public void SetCorretNumber(int number)
    {
        _currentNumber = number;
    }
    public void SetCorretNumber()
    {
        _number = _currentNumber;
        DisplayText();
    }

    public void setDefultNumber(bool defultNumber)
    {
        _hasDefultValue = defultNumber;
    }
    public void DisplayText()
    {
        if (_number <= 0)
            number_text.GetComponent<Text>().text = " ";
        else
            number_text.GetComponent<Text>().text = _number.ToString();
    }
    

    public void OnPointerClick(PointerEventData eventData)
    {
        _isSelected = true;
        GameEvent.SqureSelectMehtod(_squreIndex);
    }

    public void OnSubmit(BaseEventData eventData)
    {
       
    }
    
    
   
}
