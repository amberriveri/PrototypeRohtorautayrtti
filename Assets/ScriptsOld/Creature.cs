using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public abstract class Creature : MonoBehaviour, IMovable
{
    public float speed = 1f;

    protected Rigidbody2D rb;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        //no spinning!
        rb.freezeRotation = true;

        //you don't fall :D
        rb.gravityScale = 0;

        //smooth movement
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    public abstract Vector2 GetMovement();

    protected virtual void FixedUpdate()
    {
        Vector2 movement = GetMovement();

        /*if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
        */

        movement.Normalize();

        Vector2 newPos = rb.position + movement * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }
}
