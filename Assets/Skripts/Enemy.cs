using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 4f;
    private Target _target;

    private void Update()
    {
        Move();
    }

    private void Move() 
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        transform.LookAt(_target.transform);
    }

    public void SetTarget(Target newTarget)
    {
        _target = newTarget;
    }
}
