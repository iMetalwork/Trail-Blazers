using UnityEngine;
using System.Collections;

public class Boundaries : MonoBehaviour {

    public Vector2 lowerLeft;
    public Vector2 upperRight;
    public Vector2 enemyline;
    

    // Use this for initialization
    void Start()
    {

    }

    /*
	This method draws a box on the Scene window.
	The box indicates where the boundaries are.
	This is helpful for debugging since it only executes on the editor.
	The icon 'Boundaries' is enabled on the Gizmos menu on the Scene window.
	*/
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(new Vector3(lowerLeft.x, upperRight.y, 0.0f), new Vector3(upperRight.x, upperRight.y, 0.0f));
        Gizmos.DrawLine(new Vector3(upperRight.x, upperRight.y, 0.0f), new Vector3(upperRight.x, lowerLeft.y, 0.0f));
        Gizmos.DrawLine(new Vector3(upperRight.x, lowerLeft.y, 0.0f), new Vector3(lowerLeft.x, lowerLeft.y, 0.0f));
        Gizmos.DrawLine(new Vector3(lowerLeft.x, lowerLeft.y, 0.0f), new Vector3(lowerLeft.x, upperRight.y, 0.0f));
        Gizmos.DrawLine(new Vector3(enemyline.x, upperRight.y, 0.0f), new Vector3(enemyline.x, lowerLeft.y, 0.0f));
    }
}
