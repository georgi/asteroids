using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
    public ParticleSystem explosion;
    public GameObject asteroid;

    void OnTriggerEnter2D (Collider2D collider)
    {
        Shot shot = collider.gameObject.GetComponent<Shot> ();

        if (shot != null) {
            if (transform.localScale.x > 1 || transform.localScale.y > 1) {
                createAsteroid ();
                createAsteroid ();
                createAsteroid ();
            }

            var ps = Instantiate (explosion, transform.position, Quaternion.identity) as ParticleSystem;
            ps.transform.localScale = transform.localScale;
            ps.rigidbody2D.velocity = rigidbody2D.velocity;
            
            var q = Instantiate (explosion, shot.transform.position, Quaternion.identity) as ParticleSystem;
            q.transform.localScale = new Vector2 (0.1f, 0.1f);
            q.rigidbody2D.velocity = shot.rigidbody2D.velocity;
               
            Destroy (shot.gameObject);
            Destroy (gameObject);
        }
    }

    void createAsteroid ()
    {   
        var randPos = new Vector3 (Random.Range (0, 4), Random.Range (0, 4), 0);
        randPos /= 10;
        var a = Instantiate (asteroid, transform.position, Quaternion.identity) as GameObject;
        a.transform.position += randPos;
        a.rigidbody2D.AddForce (Random.insideUnitCircle * rigidbody2D.velocity.magnitude * 80);
        a.transform.localScale = new Vector3 (transform.localScale.x / 2, transform.localScale.y / 2, 0);
    }
}
