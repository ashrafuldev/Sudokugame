using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SudocuGrid : MonoBehaviour
{
    [SerializeField] private int rows = 0;
    [SerializeField] private int columns = 0;
    [SerializeField] private float squreOffset = 0.0f;
    [SerializeField] private float _squreScale = 1f;
    [SerializeField] private Vector2 _startPosition = new Vector2(0, 0);
    [SerializeField] private float squreGap;
    [SerializeField] private GameObject gridSqure;
    
    private List<GameObject> _gridSqures = new List<GameObject>();
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
        if(gridSqure.GetComponent<GridSqure>() == null)
            Debug.LogError("this GameObject need to have grid squre script attatch");
        CreateGrid();
        SetGridNumber(GameSetting.Instance.GetGameMode());
        
    }
    private void CreateGrid()
    {
        SpawanGridSquare();
        SetSqurePosition();
    }
    private void SpawanGridSquare()
    {
        // 1,2,3,4,5,6,7,8,9

        int squreIndex = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                _gridSqures.Add(Instantiate(gridSqure) as GameObject);
                _gridSqures[_gridSqures.Count-1].GetComponent<GridSqure>().SetSqureIndex(squreIndex);
               // _gridSqures[_gridSqures.Count - 1].transform.parent = this.transform; // instantiate this gameObject as a child of the object Holding Script
                _gridSqures[_gridSqures.Count - 1].transform.SetParent(this.transform,false);
                _gridSqures[_gridSqures.Count - 1].transform.localScale =
                    new Vector3(_squreScale, _squreScale, _squreScale);
                squreIndex++;
            }
        }
    }
    private void SetSqurePosition()
    {
        var squreRect = _gridSqures[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2(0, 0);
        Vector2 squreGapNumber= new Vector2(0, 0);
        offset.x = squreRect.rect.width * squreRect.localScale.x * squreOffset;
        offset.y = squreRect.rect.height * squreRect.localScale.y * squreOffset;

        int row_number = 0;
        int column_number = 0;

        foreach (var squre in _gridSqures)
        {
            if (column_number + 1 > columns)
            {
                row_number++;
                column_number = 0;
                squreGapNumber.x = 0f;
                _isRow = false;
            }

            var posXOffset = offset.x * column_number + (squreGapNumber.x * squreGap);
            var posYOffset = offset.y * row_number +(squreGapNumber.y * squreGap);

            // after 3 line gap
            if (column_number > 0 && column_number % 3 == 0)  
            {
                squreGapNumber.x++;
                posXOffset += squreGap;
            }

            if (row_number > 0 && row_number % 3 == 0 && _isRow == false)
            {
                _isRow = true;
                squreGapNumber.y++;
                posYOffset += squreGap;
            }
            squre.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(_startPosition.x + posXOffset, _startPosition.y - posYOffset);
            column_number++;
        }
    }
    
    private void SetGridNumber(string level)
    {
        _selectGridData = Random.Range(0, SudokuData.Instance.sudocuGame[level].Count);
        var data = SudokuData.Instance.sudocuGame[level][_selectGridData];

        SetGridSqureData(data);
        /*foreach (var squre in gridSqures_all)
        {
            squre.GetComponent<GridSqure>().SetNumber(Random.Range(0, 10));
        }*/
    }

    private void SetGridSqureData(SudokuData.SudokuBordData data)
    {
        for (int index = 0; index < _gridSqures.Count; index++)
        {
            _gridSqures[index].GetComponent<GridSqure>().SetNumber(data.unSolveData[index]);
            _gridSqures[index].GetComponent<GridSqure>().SetCorretNumber(data.solveData[index]);
            _gridSqures[index].GetComponent<GridSqure>().setDefultNumber(data.unSolveData[index] !=0 && data.unSolveData[index] == data.solveData[index]);
        }
    }

    private void CheckBordCompleted()
    {
        foreach (var squre in _gridSqures)
        {
            var comp = squre.GetComponent<GridSqure>();
            if (comp.IsCorrectNumberSet() == false)
            {
                return;
            }
        }
        GameEvent.OnBoardCompletedMethod();
    }

    public void SolveSudoku()
    {
        foreach (var squre in _gridSqures)
        {
            var com = squre.GetComponent<GridSqure>();
            com.SetCorretNumber();
        }
        CheckBordCompleted();
    }
}
