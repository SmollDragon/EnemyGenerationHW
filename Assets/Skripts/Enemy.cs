using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 2f;
    private Vector3 _direction;
    
    private void Update()
    {
        Move();
    }

    public void ChangeDirection(Vector3 newDirection)
    {
        _direction = newDirection;
    }

    private void Move()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);
    }
}
