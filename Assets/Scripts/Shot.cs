using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{

    void Start ()
    {

    }
	
    void Update ()
    {

        if (Camera.current) {
            Vector3 screen = Camera.current.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
            float w = screen.x;
            float h = screen.y;
            float x = transform.position.x;
            float y = transform.position.y;

            if (x > w || x < -w || y > h || y < -h) {
                //  if (gameObject.layer == LayerMask.NameToLayer ("shot")) {
                Destroy (gameObject);
                // }
            }
        }
    }
}
