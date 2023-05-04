using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField] private bool _rotate;
    private const int rotateMagnitude = 90;

    private void Move(Vector3 position)
    {
        transform.position += position;
    }
  
    private void Rotate(Vector3 angle)
    {
        transform.Rotate(angle);
    }   

    public void MoveRight()
    {
        Move(Vector3.right);
    }

    public void MoveLeft()
    {
        Move(Vector3.left);
    }

    public void MoveTop()
    {
        Move(Vector3.up);
    }

    public void MoveBottom()
    {
        Move(Vector3.down);
    }

    public void RotateRight()
    {
        if (!_rotate)
            return;

       Rotate(Vector3.forward * rotateMagnitude);
    }

    public void RotateLeft()
    {
        if (!_rotate)
            return;

       Rotate(Vector3.forward * rotateMagnitude);
    }
}
