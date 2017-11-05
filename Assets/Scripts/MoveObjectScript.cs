using UnityEngine;

public class MoveObjectScript : MonoBehaviour {

    private Transform myTransform;
    private Rigidbody myRigidbody;

    [SerializeField]
    private float force = 2.0f;
    [SerializeField]
    private float damp = 0.25f;
    [SerializeField]
    private Transform[] waypoints = new Transform[6];

    private void Awake()
    {
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    private int currentWaypoint = 0;
    private void Update()
    {
        Vector3 targetPosition = waypoints[currentWaypoint].position;
        Vector3 forceDirection = Vector3.Lerp(myRigidbody.velocity, (targetPosition - myTransform.position).normalized * force, Time.deltaTime * damp);

        myRigidbody.velocity = forceDirection;

        if (Vector3.Distance(myTransform.position, targetPosition) < 0.25f)
            currentWaypoint = (currentWaypoint == waypoints.Length - 1) ? 0 : currentWaypoint + 1;

        // Draw stuff in the scene view
        Debug.DrawLine(myTransform.position, targetPosition, Color.blue);
        Debug.DrawRay(myTransform.position, forceDirection * force, Color.yellow);
    }
}