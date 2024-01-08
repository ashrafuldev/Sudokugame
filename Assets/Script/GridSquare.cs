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
    private int _receivedNumber = -1;
   
    
   // public bool IsSelector => _isSelected;

    public bool IsCorrectNumberSet()
    {
        return _number == _currentNumber;
    }
    protected override void OnEnable()
    {
        GameEvent.onUpgradedSquareNumbers += OnSetNumber;
        GameEvent.onSquareSelected += OnSquareSelect;
    }

    protected override void OnDisable()
    {
        GameEvent.onUpgradedSquareNumbers -= OnSetNumber;
        GameEvent.onSquareSelected += OnSquareSelect;
    }
    
    private void OnSetNumber(int number)
    {
        _receivedNumber = number;
        SetSelectedNumberColor();

        if (!_isSelected || _hasDefaultValue) return;
        SetNumber(number);
        if (_number != _currentNumber)
        {
            var color = this.colors;
            color.normalColor = Color.red;
            this.colors = color;
            GameEvent.WrongNumberMethod();   // RED image active for live decrease
        }
        else
        {
            // _hasDefaultValue = true;
            var color = this.colors;
            color.normalColor = Color.white;
            this.colors = color;
        }
        GameEvent.OnCheckBordCompletedMethod();
    }

    private void OnSquareSelect( int squareIndexed)
    {
        _receivedNumber = _squareIndex;
        SetSelectedNumberColor();
        if (_squareIndex != squareIndexed)
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
    private void SetSelectedNumberColor()
    {
        if (_number == _receivedNumber)
        {
            var color = this.colors;
            color.normalColor = Color.cyan;
            this.colors = color;
        }
        else
        {
            var color = this.colors;
            color.normalColor = Color.white;
            this.colors = color;   
        }
    }
    
    public void SetSquareIndex(int index)
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

    private void DisplayText()
    {
        numberText.GetComponent<Text>().text = _number <= 0 ? " " : _number.ToString();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        _isSelected = true;
        GameEvent.SquareSelectedMethod(_squareIndex);
    }

    public void OnSubmit(BaseEventData eventData)
    {
       
    }
}
