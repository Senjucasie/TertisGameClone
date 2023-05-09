using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _playerInputReader;
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

    private void OnEnable()
    {
        _playerInputReader.OnMoveRightEvent += Right;
        _playerInputReader.OnMoveDownevent += Down;
        _playerInputReader.OnMoveLeftEvent += Left;
        _playerInputReader.OnRotateEvent += RotateShape;
    }
    private void OnDisable()
    {
        _playerInputReader.OnMoveRightEvent -= Right;
        _playerInputReader.OnMoveDownevent -= Down;
        _playerInputReader.OnMoveLeftEvent -= Left;
        _playerInputReader.OnRotateEvent -= RotateShape;
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
                    LandShape();
                }
            }
        }   
    }

    private void LandShape()
    {
        _activeShape.MoveTop();
        _board.StoreShapeInGrid(_activeShape);
        _activeShape = _spawner.SpawnShape();
        _board.ClearAllRows();
    }

    private void Right()
    {
        _activeShape.MoveRight();
        if(!_board.IsValidPosition(_activeShape))
        {
            _activeShape.MoveLeft();
        }
    }

    private void Left() 
    { 
        _activeShape.MoveLeft();
        if (!_board.IsValidPosition(_activeShape))
        {
            _activeShape.MoveRight();
        }
    }

    private void Down() 
    {
        _activeShape.MoveBottom();

        if (!_board.IsValidPosition(_activeShape))
        {
        _activeShape.MoveTop();
        }
    }

    private void RotateShape()
    {
        _activeShape.RotateRight();
        if (!_board.IsValidPosition(_activeShape))
        {
            _activeShape.RotateLeft();
        }

    }

}
