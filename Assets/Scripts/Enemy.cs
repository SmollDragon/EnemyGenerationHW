using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 7f;
    private Target _target;

    private void Update()
    {
        Move();
        DestroyIfTargetReached();
    }

    public void SetTarget(Target newTarget)
    {
        _target = newTarget;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        transform.LookAt(_target.transform);        
    }

    private void DestroyIfTargetReached()
    {
        float targetDistance = Vector3.Distance(transform.position, _target.transform.position);

        if (targetDistance < 0.1f)
        {
            Destroy(gameObject);
        }
    }  
}