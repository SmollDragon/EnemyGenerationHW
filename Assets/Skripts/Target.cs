using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    private Transform _endPoint;   
    private Transform _startPoint;   
    private Transform _currentTarget;
    private float _speed = 6f;

    private void Start()
    {
        SetPoints();
        _currentTarget = _endPoint;              
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.LookAt(_currentTarget);
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _currentTarget.position) < 0.1f)
        {
            if (_currentTarget.position == _startPoint.position)
            {
                _currentTarget = _endPoint;
            }
            else
            {
                _currentTarget = _startPoint;
            }
        }
    }

    private void SetPoints()
    {
        int offsetEndPoint = 10;

        _startPoint = new GameObject("StartPoint").transform;
        _startPoint.position = transform.position;

        _endPoint = new GameObject("EndPoint").transform;
        _endPoint.position = _startPoint.position + new Vector3(offsetEndPoint, 0, 0);
    }
}