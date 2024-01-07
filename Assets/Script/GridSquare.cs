using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class GridSquare : Selectable, IPointerClickHandler, ISubmitHandler
{
    [FormerlySerializedAs("number_text")] public GameObject numberText;
    private int _number;
    private bool _isSelected;
    private int _squareIndex = -1;
    private int _currentNumber;
    private bool _hasDefaultValue;
    
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
        
        if (_isSelected && _hasDefaultValue == false)  
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
        if (_squareIndex != squreIndexed)
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
        _squareIndex = index;
    }

    public void SetCorrectNumber(int number)
    {
        _currentNumber = number;
    }
    public void SetCorrectNumber()
    {
        _number = _currentNumber;
        DisplayText();
    }

    public void SetDefaultNumber(bool defaultNumber)
    {
        _hasDefaultValue = defaultNumber;
    }
    public void DisplayText()
    {
        if (_number <= 0)
            numberText.GetComponent<Text>().text = " ";
        else
            numberText.GetComponent<Text>().text = _number.ToString();
    }
    

    public void OnPointerClick(PointerEventData eventData)
    {
        _isSelected = true;
        GameEvent.SqureSelectMehtod(_squareIndex);
    }

    public void OnSubmit(BaseEventData eventData)
    {
       
    }
    
    
   
}
