using UnityEngine;

public class Spawner:MonoBehaviour
{
    [SerializeField]private Shape[] _shapeArray;

    private void Awake()
    {
        Vector2 position =Vector2Int.RoundToInt(new Vector2(transform.position.x, transform.position.y));
        transform.position = position;
    }

    private Shape GetRandomShape()
    {
        Shape shape = _shapeArray[Random.Range(0, _shapeArray.Length)];
        if(shape==null)
        {
            Debug.LogWarning("Couldnt find the shape in the array to spawn");
            return null;
        }
        else
        {
            return shape;
        }
    }

    public Shape SpawnShape()
    {
        Shape shape = Instantiate(GetRandomShape(), transform.position, Quaternion.identity) as Shape;

        return shape;
    }
}