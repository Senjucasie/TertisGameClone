using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour,PlayerInputControl.IPlayerActions
{
    private PlayerInputControl _playerControl;

    public event Action OnMoveRightEvent;
    public event Action OnMoveLeftEvent;
    public event Action OnMoveDownevent;
    public event Action OnRotateEvent;

    // Start is called before the first frame update
    void Start()
    {
        InitControl();
    }

    private void InitControl()
    {
        _playerControl = new PlayerInputControl();
        _playerControl.Player.SetCallbacks(this);
        _playerControl.Enable();

    }

    public void OnMoveDown(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        OnMoveDownevent?.Invoke();
    }

    public void OnMoveLeft(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        OnMoveLeftEvent?.Invoke();
    }

    public void OnMoveRight(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        OnMoveRightEvent?.Invoke(); 
    }

    private void OnDestroy()
    {
        _playerControl.Disable();
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        OnRotateEvent?.Invoke();
    }
}
