using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public ParticleSystem explosion;
    public GameObject shot;
    public int lives;
    public float acceleration;
    public float angularSpeed;
    public float maxVelocity;
    public float shotSpeed;
    public Vector2 startPosition;

    private Animator animator;
    private int stateInvincible = Animator.StringToHash ("Base Layer.invincible");

    void Start ()
    {
        animator = GetComponent<Animator> ();
    }

    bool isInvincible ()
    {
        return animator.GetCurrentAnimatorStateInfo (0).nameHash == stateInvincible;
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        var asteroid = collision.gameObject.GetComponent<Asteroid> ();
    
        if (asteroid != null) {
            animator.Play (stateInvincible);
            Instantiate (explosion, transform.position, Quaternion.identity);

            transform.position = startPosition;
            rigidbody2D.velocity = new Vector2 (0, 0);

            lives = lives - 1;

            if (lives == 0)
                Destroy (gameObject);
        }
    }

    void Update ()
    {
        float inputX = Input.GetAxis ("Horizontal");
        float inputY = Input.GetAxis ("Vertical");

        rigidbody2D.angularVelocity = -inputX * angularSpeed;

        rigidbody2D.AddForce (transform.rotation * Vector2.up * inputY * acceleration);

        rigidbody2D.velocity = BoundedVelocity (rigidbody2D.velocity);

        if (Input.GetButtonDown ("Fire1")) {
            GameObject s = Instantiate (shot, transform.position + transform.up / 1.2f, Quaternion.identity) as GameObject;
            s.rigidbody2D.AddForce (transform.up * shotSpeed);
        }

        collider2D.isTrigger = isInvincible ();
    }

    Vector2 BoundedVelocity (Vector2 velocity)
    {
        return (velocity.magnitude > maxVelocity) ?
            velocity.normalized * maxVelocity : velocity;
    }
}
