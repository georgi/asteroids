using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
    void Awake ()
    {
        Destroy (gameObject, 5);
    }
}
