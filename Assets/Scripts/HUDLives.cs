using UnityEngine;
using System.Collections;

public class HUDLives : MonoBehaviour
{
    public Player player;
	
    void OnGUI ()
    {
        GUI.Label (new Rect (0, 0, 100, 100), string.Format ("LIVES {0}", player.lives));
    }
}
