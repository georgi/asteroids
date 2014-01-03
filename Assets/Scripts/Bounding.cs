using UnityEngine;
using System.Collections;

public class Bounding : MonoBehaviour
{

    void Update ()
    {
        transform.position = BoundedPosition (transform.position);

    }

    Vector2 BoundedPosition (Vector2 position)
    {
        if (Camera.current) {
            Vector3 screen = Camera.current.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
            float w = screen.x;
            float h = screen.y;
            float x = position.x;
            float y = position.y;

            return
                (x > w) ? new Vector2 (-w, y) :
                (x < -w) ? new Vector2 (w, y) :
                (y > h) ? new Vector2 (x, -h) :
                (y < -h) ? new Vector2 (x, h) : position;
        } else
            return position;
    }
}