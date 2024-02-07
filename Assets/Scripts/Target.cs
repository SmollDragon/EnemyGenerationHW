using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private RoutePointCreator _routeManager;
    private Transform _currentPoint;
    private Transform _tempPoint;
    private bool _isAvoidingObstacle = false;
    private float _speed = 6f;
    private float _checkObstacleDistance = 3f;

    private void Start()
    {
        _currentPoint = GetRoutePoint();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (CheckObstacle(_checkObstacleDistance))
        {
            SetTempPoint();
        }

        if (_isAvoidingObstacle)
        {
            MoveToPoint(_tempPoint);
        }
        else
        {
            MoveToPoint(_currentPoint);
        }
    }

    private void MoveToPoint(Transform point)
    {
        transform.LookAt(point);
        transform.position = Vector3.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, point.position) < 0.1f)
        {
            if (_isAvoidingObstacle && point == _tempPoint)
            {
                Destroy(_tempPoint.gameObject);
                _tempPoint = null;
                _isAvoidingObstacle = false;
            }
            else if (_isAvoidingObstacle == false && point == _currentPoint)
            {
                _currentPoint = GetRoutePoint();
            }
        }
    }

    private void SetTempPoint()
    {
        if (_tempPoint == null)
        {
            _tempPoint = new GameObject("TempPoint").transform;
        }

        _tempPoint.position = CalculateAvoidancePoint();
        _isAvoidingObstacle = true;
    }

    private bool CheckObstacle(float checkObstacleDistance)
    {
        Ray checkRay = new Ray(transform.position, transform.forward);

        return Physics.Raycast(checkRay, out RaycastHit hit, checkObstacleDistance) && hit.transform.GetComponent<Obstacle>() != null;
    }

    private Vector3 CalculateAvoidancePoint()
    {
        float avoidDistance = 3f;
        Vector3 avoidDirection = Vector3.Cross(transform.forward, Vector3.up);

        return transform.position + avoidDirection * avoidDistance;
    }

    private Transform GetRoutePoint()
    {
        int randomIndex = Random.Range(0, _routeManager.RoutePoints.Length);

        while (_routeManager.RoutePoints[randomIndex] == _currentPoint)
        {
            randomIndex = Random.Range(0, _routeManager.RoutePoints.Length);
        }

        return _routeManager.RoutePoints[randomIndex];
    }
}