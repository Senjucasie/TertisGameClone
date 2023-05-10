using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController Instance
    {
        get; private set;
    }
    [SerializeField] private PlayerInputReader _playerInputReader;
    [SerializeField] private Board _board;
    [SerializeField] private Spawner _spawner;

    [SerializeField] private float _dropInterval;
    private float _timeForDrop;
    private bool _gameOver;
    private Shape _activeShape;
    public event Action OnGameOver;
    private void Awake()
    {
        Instance = this;
        _timeForDrop = 0;
        _gameOver = false;
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
        if (_activeShape == null || _gameOver)
            return;

        _timeForDrop += Time.deltaTime;
        if (_timeForDrop >= _dropInterval)
        {
            _timeForDrop = 0;
            _activeShape.MoveBottom();

            if (!_board.IsValidPosition(_activeShape))
            {
                if (_board.isOverLimit(_activeShape))
                {
                    GameOver();
                }
                else
                {
                    LandShape();
                }
            }
        }

    }

    private void GameOver()
    {
        _activeShape.MoveTop();
        _gameOver = true;
        OnGameOver?.Invoke();
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
        if (_gameOver) return;

        _activeShape.MoveRight();
        if (!_board.IsValidPosition(_activeShape))
        {
            _activeShape.MoveLeft();
        }
    }

    private void Left()
    {
        if (_gameOver) return;

        _activeShape.MoveLeft();
        if (!_board.IsValidPosition(_activeShape))
        {
            _activeShape.MoveRight();
        }
    }

    private void Down()
    {
        if (_gameOver) return;

        _activeShape.MoveBottom();
        if (!_board.IsValidPosition(_activeShape))
        {
            _activeShape.MoveTop();
        }
    }

    private void RotateShape()
    {
        if (_gameOver) return;

        _activeShape.RotateRight();
        if (!_board.IsValidPosition(_activeShape))
        {
            _activeShape.RotateLeft();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
