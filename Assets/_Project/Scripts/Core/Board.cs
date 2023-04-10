using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _grid;

    [SerializeField]private float _verticalGrid, _horizontalGrid;

    void Start()
    {
        DrawGrid(_grid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DrawGrid(GameObject grid)
    {
        for(int vertical=0;vertical<=_verticalGrid;vertical++)
        {
            for(int horizontal=0;horizontal<_horizontalGrid;horizontal++)
            {
                GameObject spawnedgrid = Instantiate(_grid, new Vector3(horizontal, vertical, 0), Quaternion.identity) ;
                spawnedgrid.name = "Grid" + vertical +"," +horizontal;
                spawnedgrid.transform.parent = transform;
            }
        }
    }
}
