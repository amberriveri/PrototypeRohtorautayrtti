using UnityEngine;

public class MovementDebugger : MonoBehaviour
{
    public MonoBehaviour target;

    void Update()
    {
        IMovable movable = target as IMovable;

        if ( movable != null)
        {
            Vector2 movement = movable.GetMovement();
            //Debug.Log("Movement: " + movement);
        }
    }
}
