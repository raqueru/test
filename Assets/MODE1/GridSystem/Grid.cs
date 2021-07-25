using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System;

public class Grid<TGridObject>
{
    private int width;
    private int height;
    public float CellSize;
    private TGridObject[,] gridArray;
    private TextMesh[,] debugTextArray;
    private Vector3 originPosition;
    private bool showgrid=true;

    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }

    
    public Grid(int width, int height, float CellSize, Vector3 originPosition, Func<Grid<TGridObject>, int, int, TGridObject> createGridObj, bool showvalues=false)
    {



        this.width = width;
        this.height = height;
        this.CellSize = CellSize;
        this.originPosition = originPosition;
       
        gridArray = new TGridObject[width, height];
        TextMesh[,] debugTextArray = new TextMesh[width, height];
        gridArray = new TGridObject[width, height];
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = createGridObj(this, x, y);
            }
        }
        
        if (showgrid == true)
        {
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    if (showvalues)
                    {
                        debugTextArray[x, y] = Utils.CreateWorldText(gridArray[x, y]?.ToString(), null, GetWorldPosition(x, y) + new Vector3(CellSize, CellSize) * 0.5f, 20, Color.white,
                            TextAnchor.MiddleCenter);
                    }
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);

            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
            if (showvalues)
            {
                OnGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) =>
                 {
                     debugTextArray[eventArgs.x, eventArgs.y].text = gridArray[eventArgs.x, eventArgs.y]?.ToString();
                 };
            }
        }

    }

 
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * CellSize + originPosition;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / CellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / CellSize);

    }

    public void SetValue(int x, int y, TGridObject value)
    {
        if (x <= width && x >= 0 && y <= height && y >= 0)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
            if (OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });

        }
    }
    public void SetValue(Vector3 worldPos, TGridObject value)
    {
        int x, y;
        GetXY(worldPos, out x, out y);
        SetValue(x, y, value);
    }

    public int GetHeight()
    {
        return height;
    }
    public int GetWidth()
    {
        return width;
    }
    public float GetCellSize()
    {
        return CellSize;
    }
    public TGridObject GetValue(int x, int y)
    {

        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        return default(TGridObject);
    }
    public TGridObject GetWorldValue(Vector3 WoldPosition)
    {
        int x, y;
        GetXY(WoldPosition, out x, out y);
        return GetValue(x, y);
    }
    public void TriggerGridObjectsChanged(int x, int y)
    {
        if (OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });

    }

    public void ShowGrid()
    {
        showgrid=!showgrid;
    }
}