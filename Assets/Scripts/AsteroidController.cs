using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

    void Start () {
	
    }
	
    void Update () {
	
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
    }
}
