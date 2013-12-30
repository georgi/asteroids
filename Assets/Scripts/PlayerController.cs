using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float acceleration = 10;
    public float angularSpeed = 500;
    public float maxVelocity = 5;

    void Start () {
    }

    void Update ()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        rigidbody2D.angularVelocity = -inputX * angularSpeed;

        // if (rigidbody2D.velocity.magnitude < 30)
        rigidbody2D.AddForce(transform.rotation * Vector2.up * 2);

        transform.position = Bounding.BoundedPosition(transform.position);
        rigidbody2D.velocity = BoundedVelocity(rigidbody2D.velocity);
    }

    Vector2 BoundedVelocity(Vector2 velocity)
    {
        return (velocity.magnitude > maxVelocity) ?
            velocity.normalized * maxVelocity : velocity;
    }
}
