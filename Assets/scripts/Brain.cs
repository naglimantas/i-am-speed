using UnityEngine;

// AI CAR
public class Brain : MonoBehaviour
{
    public float speed;
    public Path path;
    Transform target;

    Vehicle vehicle;

    void Start()
    {
        vehicle = GetComponent<Vehicle>();
        target = path.GetClosestPoint(transform.position);
    }

    void Update()
    {
        vehicle.Gas();
        vehicle.Turn(1);

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        var distance = Vector3.Distance(transform.position, target.position);
        if (distance < 0.1f)
        {
            target = path.GetNextPoint(target);
        }
    }
}