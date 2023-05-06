using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
   
    [SerializeField] private GameObject _gridSprite;

    [SerializeField] Transform[,] _grid;    

    [SerializeField]private int _verticalGrid, _horizontalGrid;

    void Start()
    {
        _grid = new Transform[_horizontalGrid, 30];
        DrawGrid(_gridSprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawGrid(GameObject _gridSprite)
    {
        for(int vertical=0;vertical<=_verticalGrid;vertical++)
        {
            for(int horizontal=0;horizontal<_horizontalGrid;horizontal++)
            {
                GameObject spawnedgrid = Instantiate(_gridSprite, new Vector3(horizontal, vertical, 0), Quaternion.identity) ;
                spawnedgrid.name = "Grid" + vertical +"," +horizontal;
                spawnedgrid.transform.parent = transform;
            }
        }
    }
    bool IsGridOccupied(int x, int y,Shape shape)
    {
        return _grid[x, y] != null ;
    }
    bool IsWithinBoard(int x, int y)
    {
        return x >= 0 && x <= _horizontalGrid && y >= 0;    
    }

    public bool IsValidPosition(Shape currentshape)
    {
        foreach(Transform square in currentshape.transform)
        {
         if (!IsWithinBoard((int)square.position.x, (int)square.position.y)|| IsGridOccupied((int)square.position.x, (int)square.position.y,currentshape))
            return false;
        }

    return true;
    }

    public void StoreInGrid(Shape shape)
    {
    if (shape == null) return;
        foreach(Transform square in shape.transform)
        {
            _grid[(int)square.position.x, (int)square.position.y] = shape.transform;
        }

    }
}
