using UnityEngine;

// AI CAR
public class Car : MonoBehaviour
{
    public float speed;
    public Path path;
    Transform target;

    void Start()
    {
        target = path.GetClosestPoint(transform.position);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        var distance = Vector3.Distance(transform.position, target.position);
        if (distance < 0.1f)
        {
            target = path.GetNextPoint(target);
        }
    }
}