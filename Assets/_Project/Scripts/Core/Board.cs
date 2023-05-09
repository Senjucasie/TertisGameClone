using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
   
    [SerializeField] private GameObject _gridSprite;

    [SerializeField] Transform[,] _grid;    

    [SerializeField]private int _width, _height;

    [SerializeField] private int _header;

    void Start()
    {
        _grid = new Transform[_width, _height];
        DrawGrid(_gridSprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawGrid(GameObject _gridSprite)
    {
        for(int y=0;y<_height-_header;y++)
        {
            for(int x=0;x<_width; x++)
            {
                GameObject spawnedgrid = Instantiate(_gridSprite, new Vector3(x, y, 0), Quaternion.identity) ;
                spawnedgrid.name = "Grid" + x +"," +y;
                spawnedgrid.transform.parent = transform;
            }
        }
    }

    private bool IsGridOccupied(int x, int y,Shape shape)
    {
        
        return (_grid[x, y] != null &&  _grid[x,y].parent != shape.transform) ;
        
    }

    private bool IsWithinBoard(int x, int y)
    {
        return (x >= 0 && x < _width && y >= 0);    
    }

    public bool IsValidPosition(Shape currentshape)
    {
        
        foreach(Transform square in currentshape.transform)
        {
            Vector2 pos = Vectorf.Round(square.position);
            if (!IsWithinBoard((int)pos.x, (int)pos.y) || 
            IsGridOccupied((int)pos.x, (int)pos.y,currentshape))
                return false;
        }

    return true;
    }

    public void StoreShapeInGrid(Shape shape)
    {
        if (shape == null) return;  

        foreach(Transform square in shape.transform)
        {
            Vector2 pos = Vectorf.Round(square.position);
            _grid[(int)pos.x, (int)pos.y] = square;
        }

    }

    private bool IsRowFilled(int y)
    {
        for(int x=0; x<_width; x++)
        {
            if(_grid[x,y]==null) return false;
        }
        return true;
    }

    private void ClearRow(int y)
    {
        for (int x = 0; x < _width; x++)
        {
            if(_grid[x,y]!=null)
            {
                Destroy(_grid[x, y].gameObject);
                
            }
            _grid[x, y] = null;
        }
    }

    private void ShiftOneRowDown(int y)
    {
        for(int x=0; x<_width;x++ )
        {
            if(_grid[x,y]!=null)
            {
                _grid[x, y - 1] = _grid[x, y];
                _grid[x, y] = null;
                _grid[x, y - 1].position += Vector3.down;
            }
        }
    }

    private void ShiftRowsDown(int startY)
    {
        for(int y=startY; y<_height; y++)
        {
            ShiftOneRowDown(y);
        }
    }

    public void ClearAllRows()
    {
    for (int y=0;y<_height;y++)
    {
        if(IsRowFilled(y))
        {
            ClearRow(y);
            ShiftRowsDown(y + 1);
            y--;
        }
    }
    }
}
