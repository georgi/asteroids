using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
    public GameObject asteroid;
    public Camera sceneCamera;
    public int asteroidCount;
    public float asteroidVelocity;

    void Awake ()
    {
        Vector3 screen = sceneCamera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));

        for (int i = 0; i < asteroidCount; i++) {
            GameObject o = Instantiate (asteroid, 
			            new Vector3 (Random.Range (-screen.x, screen.x), Random.Range (-screen.y, screen.y), 0),
			            Quaternion.identity) as GameObject;

            o.rigidbody2D.AddForce (Random.insideUnitCircle * asteroidVelocity);
            o.rigidbody2D.AddTorque (Random.Range (-50, 50));

            o.transform.localScale += new Vector3 (Random.Range (0, 2), Random.Range (0, 2), 0);
        }
    }
	
    void Update ()
    {
	
    }
}
