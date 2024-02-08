using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private RoutePointCreator _routeManager;
    private Transform _currentPoint;
    private Vector3 _tempPoint;
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
            MoveToPoint(_currentPoint.position);
        }
    }

    private void MoveToPoint(Vector3 destination)
    {
        transform.LookAt(destination);
        transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination) < 0.1f)
        {
            if (_isAvoidingObstacle && destination == _tempPoint)
            {
                _isAvoidingObstacle = false;
            }
            else if (_isAvoidingObstacle == false && Vector3.Distance(transform.position, _currentPoint.position) < 0.1f)
            {
                _currentPoint = GetRoutePoint();
            }
        }
    }

    private void SetTempPoint()
    {
        _tempPoint = CalculateAvoidancePoint();
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
        int randomIndex = Random.Range(0, _routeManager.GetRoutePoints().Length);

        while (_routeManager.GetRoutePoints()[randomIndex] == _currentPoint)
        {
            randomIndex = Random.Range(0, _routeManager.GetRoutePoints().Length);
        }

        return _routeManager.GetRoutePoints()[randomIndex];
    }
}