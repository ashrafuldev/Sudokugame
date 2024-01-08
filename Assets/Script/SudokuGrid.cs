using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SudokuGrid : MonoBehaviour
{
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [FormerlySerializedAs("squreOffset")] [SerializeField] private float squareOffset;
    [FormerlySerializedAs("_squreScale")] [SerializeField] private float squareScale = 1f;
    [FormerlySerializedAs("_startPosition")] [SerializeField] private Vector2 startPosition = new Vector2(0, 0);
    [FormerlySerializedAs("squreGap")] [SerializeField] private float squareGap;
    [FormerlySerializedAs("gridSqure")] [SerializeField] private GameObject gridSquare;
    
    private readonly List<GameObject> _gridSquares = new List<GameObject>();
    private int _selectGridData = -1;
    private bool _isRow;

    private void OnEnable()
    {
        GameEvent.onCheckBordCompleted+= CheckBordCompleted;
    }

    private void OnDisable()
    {
        GameEvent.onCheckBordCompleted-= CheckBordCompleted;
    }

    private void Start()
    {
        if(gridSquare.GetComponent<GridSquare>() == null)
            Debug.LogError("this GameObject need to have grid square script attach");
        CreateGrid();
        SetGridNumber(GameSetting.Instance.GetGameMode());
    }
    private void CreateGrid()
    {
        SpawnGridSquare();
        SetSquarePosition();
    }
    private void SpawnGridSquare()
    {
        // 1,2,3,4,5,6,7,8,9

        int squareIndex = 0;
        for (var row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                _gridSquares.Add(Instantiate(gridSquare));
                _gridSquares[^1].GetComponent<GridSquare>().SetSquareIndex(squareIndex);
               // _gridSquares[_gridSquares.Count - 1].transform.parent = this.transform; // instantiate this gameObject as a child of the object Holding Script
                _gridSquares[^1].transform.SetParent(this.transform,false);
                _gridSquares[^1].transform.localScale =
                    new Vector3(squareScale, squareScale, squareScale);
                squareIndex++;
            }
        }
    }
    private void SetSquarePosition()
    {
        var squareRect = _gridSquares[0].GetComponent<RectTransform>();
        var offset = new Vector2(0, 0);
        var squareGapNumber= new Vector2(0, 0);
        var rect = squareRect.rect;
        var localScale = squareRect.localScale;
        offset.x = rect.width * localScale.x * squareOffset;
        offset.y = rect.height * localScale.y * squareOffset;

        var rowNumber = 0;
        var columnNumber = 0;

        foreach (var square in _gridSquares)
        {
            if (columnNumber + 1 > columns)
            {
                rowNumber++;
                columnNumber = 0;
                squareGapNumber.x = 0f;
                _isRow = false;
            }

            var posXOffset = offset.x * columnNumber + (squareGapNumber.x * squareGap);
            var posYOffset = offset.y * rowNumber +(squareGapNumber.y * squareGap);

            // after 3 line gap
            if (columnNumber > 0 && columnNumber % 3 == 0)  
            {
                squareGapNumber.x++;
                posXOffset += squareGap;
            }

            if (rowNumber > 0 && rowNumber % 3 == 0 && _isRow == false)
            {
                _isRow = true;
                squareGapNumber.y++;
                posYOffset += squareGap;
            }
            square.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(startPosition.x + posXOffset, startPosition.y - posYOffset);
            columnNumber++;
        }
    }
    
    private void SetGridNumber(string level)
    {
        _selectGridData = Random.Range(0, SudokuData.Instance.sudokuGame[level].Count);
        var data = SudokuData.Instance.sudokuGame[level][_selectGridData];

        SetGridSquareData(data);
        
        /*foreach (var square in gridSquares_all)
        {
            square.GetComponent<GridSquare>().SetNumber(Random.Range(0, 10));
        }*/
    }

    private void SetGridSquareData(SudokuData.SudokuBordData data)
    {
        for (var index = 0; index < _gridSquares.Count; index++)
        {
            _gridSquares[index].GetComponent<GridSquare>().SetNumber(data.UnSolveData[index]);
            _gridSquares[index].GetComponent<GridSquare>().SetCorrectNumber(data.SolveData[index]);
            _gridSquares[index].GetComponent<GridSquare>().SetDefaultNumber(data.UnSolveData[index] !=0 && data.UnSolveData[index] == data.SolveData[index]);
        }
    }

    private void CheckBordCompleted()
    {
        if (_gridSquares.Select(square => square.GetComponent<GridSquare>()).Any(comp => comp.IsCorrectNumberSet() == false))
        {
            return;
        }
        GameEvent.OnBoardCompletedMethod();
    }

    public void SolveSudoku()
    {
        foreach (var square in _gridSquares)
        {
            var com = square.GetComponent<GridSquare>();
            com.SetCorrectNumber();
        }
        CheckBordCompleted();
    }
}
