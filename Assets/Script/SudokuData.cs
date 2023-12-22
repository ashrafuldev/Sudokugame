using System.Collections.Generic;
using UnityEngine;

public class SudocuEasyData: MonoBehaviour
{
   public static List<SudokuData.SudokuBordData> GetData()
   {
      List<SudokuData.SudokuBordData> data = new List<SudokuData.SudokuBordData>();
      data.Add(new SudokuData.SudokuBordData(
         new int[81]{0,1,4,0,0,0,0,3,0,3,0,0,5,1,0,8,0,0,0,8,0,0,0,9,0,0,6,0,0,1,8,0,0,6,0,0,0,0,3,2,5,6,4,0,0,0,0,6,0,0,7,2,0,0,9,0,0,7,0,0,0,4,0,0,0,5,0,8,4,0,0,2,0,4,0,0,0,0,7,1,0,},
         new int[81]{2,1,4,6,7,8,9,3,5,3,6,9,5,1,2,8,7,4,5,8,7,4,3,9,1,2,6,4,2,1,8,9,3,6,5,7,7,9,3,2,5,6,4,8,1,8,5,6,1,4,7,2,9,3,9,3,2,7,6,1,5,4,8,1,7,5,9,8,4,3,6,2,6,4,8,3,2,5,7,1,9,})
      );
      return data;
   }
}

public class SudocuMediumData: MonoBehaviour
{
   public static List<SudokuData.SudokuBordData> GetData()
   {
      List<SudokuData.SudokuBordData> data = new List<SudokuData.SudokuBordData>();
      data.Add(new SudokuData.SudokuBordData(
         new int[81]{0,0,9,0,4,0,0,0,5,2,5,4,0,1,0,0,0,7,0,0,0,0,0,5,0,1,0,0,6,0,0,0,8,0,0,0,8,0,1,5,3,7,9,0,4,0,0,0,4,0,0,0,3,0,0,4,0,1,0,0,0,0,0,7,0,0,0,9,0,5,4,6,6,0,0,0,5,0,1,0,0,},
         new int[81]{1,7,9,8,4,3,6,2,5,2,5,4,6,1,9,3,8,7,3,8,6,2,7,5,4,1,9,4,6,3,9,2,8,7,5,1,8,2,1,5,3,7,9,6,4,5,9,7,4,6,1,8,3,2,9,4,5,1,8,6,2,7,3,7,1,8,3,9,2,5,4,6,6,3,2,7,5,4,1,9,8,})
         );
      return data;
   }
}

public class SudocuHeardData: MonoBehaviour
{
   public static List<SudokuData.SudokuBordData> GetData()
   {
      List<SudokuData.SudokuBordData> data = new List<SudokuData.SudokuBordData>();
      data.Add(new SudokuData.SudokuBordData(
         new int[81]{0,0,9,0,4,0,0,0,5,2,5,4,0,1,0,0,0,7,0,0,0,0,0,5,0,1,0,0,6,0,0,0,8,0,0,0,8,0,1,5,3,7,9,0,4,0,0,0,4,0,0,0,3,0,0,4,0,1,0,0,0,0,0,7,0,0,0,9,0,5,4,6,6,0,0,0,5,0,1,0,0,},
         new int[81]{1,7,9,8,4,3,6,2,5,2,5,4,6,1,9,3,8,7,3,8,6,2,7,5,4,1,9,4,6,3,9,2,8,7,5,1,8,2,1,5,3,7,9,6,4,5,9,7,4,6,1,8,3,2,9,4,5,1,8,6,2,7,3,7,1,8,3,9,2,5,4,6,6,3,2,7,5,4,1,9,8,})
      );
      return data;
   }
}

public class SudocuVeryHeardData: MonoBehaviour
{
   public static List<SudokuData.SudokuBordData> GetData()
   {
      List<SudokuData.SudokuBordData> data = new List<SudokuData.SudokuBordData>();
      data.Add(new SudokuData.SudokuBordData(
         new int[81]{0,0,9,0,4,0,0,0,5,2,5,4,0,1,0,0,0,7,0,0,0,0,0,5,0,1,0,0,6,0,0,0,8,0,0,0,8,0,1,5,3,7,9,0,4,0,0,0,4,0,0,0,3,0,0,4,0,1,0,0,0,0,0,7,0,0,0,9,0,5,4,6,6,0,0,0,5,0,1,0,0,},
         new int[81]{1,7,9,8,4,3,6,2,5,2,5,4,6,1,9,3,8,7,3,8,6,2,7,5,4,1,9,4,6,3,9,2,8,7,5,1,8,2,1,5,3,7,9,6,4,5,9,7,4,6,1,8,3,2,9,4,5,1,8,6,2,7,3,7,1,8,3,9,2,5,4,6,6,3,2,7,5,4,1,9,8,})
      );
      return data;
   }
}

public class SudokuData : MonoBehaviour
{
   public static SudokuData Instance;

   public struct SudokuBordData
   {
      public int[] unSolveData;
      public int[] solveData;
      public SudokuBordData(int[] unSolveData, int[] solveData)
      {
         this.unSolveData = unSolveData;
         this.solveData = solveData;
      }
   };

   public Dictionary<string, List<SudokuBordData>> sudocuGame = new Dictionary<string, List<SudokuBordData>>();
   
   private void Awake()
   {
      if (Instance == null)
         Instance = this;
      else 
         Destroy(this);
   }

   private void Start()
   {
      sudocuGame.Add("EASY",SudocuEasyData.GetData());
      sudocuGame.Add("MEDIUM",SudocuMediumData.GetData());
      sudocuGame.Add("HEARD",SudocuHeardData.GetData());
      sudocuGame.Add("VERY_HEARD",SudocuVeryHeardData.GetData());
   }
}
