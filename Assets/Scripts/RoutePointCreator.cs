using UnityEngine;

public class RoutePointCreator : MonoBehaviour
{
    private Transform[] _routePoints;
    private int _pointsCount = 30;

    private void Awake()
    {
        GenerateRandomPoint();
    }

    public Transform[] GetRoutePoints() 
    {
        return (Transform[])_routePoints.Clone();
    }

    private void GenerateRandomPoint()
    {
        float colliderCheckDistance = 3f;
        GameObject parentObject = this.gameObject;
        _routePoints = new Transform[_pointsCount];

        for (int i = 0; i < _pointsCount;)
        {
            Vector3 randomPosition = GetRandomPosition();
            Collider[] hitColliders = Physics.OverlapBox(randomPosition, new Vector3(colliderCheckDistance, 0f, colliderCheckDistance));

            if (hitColliders.Length == 0)
            {
                CreateRoutePoint(parentObject, i, randomPosition);
                i++;
            }
        }
    }

    private void CreateRoutePoint(GameObject parentObject, int pointNumber, Vector3 position)
    {
        GameObject routePointObject = new GameObject("Route Point" + pointNumber);

        routePointObject.transform.position = position;
        routePointObject.transform.parent = parentObject.transform;
        _routePoints[pointNumber] = routePointObject.transform;
    }

    private Vector3 GetRandomPosition()
    {
        float groundHeight = 102f;
        float minCoordinates = 25f;
        float maxCoordinates = 180f;

        float x = Random.Range(minCoordinates, maxCoordinates);
        float z = Random.Range(minCoordinates, maxCoordinates);

        return new Vector3(x, groundHeight, z);
    }
}