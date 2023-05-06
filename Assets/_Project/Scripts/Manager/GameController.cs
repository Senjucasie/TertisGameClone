using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Board _board;
    [SerializeField] private Spawner _spawner;

    [SerializeField]private float _dropInterval;
    private float _timeForDrop;

    private Shape _activeShape;

    private void Awake()
    {
        _timeForDrop = 0;
    }
    private void Start()
    {
        if (_activeShape == null)
            _activeShape = _spawner.SpawnShape();
    }

    private void Update()
    {
        if(_activeShape !=null)
        {
            _timeForDrop += Time.deltaTime;
            if(_timeForDrop>=_dropInterval)
            {
                _timeForDrop = 0;
                _activeShape.MoveBottom();

                if(!_board.IsValidPosition(_activeShape))
                {
                    _activeShape.MoveTop();
                    _board.StoreInGrid(_activeShape);
                    _activeShape = _spawner.SpawnShape();
                }
            }
        }
    }
}
