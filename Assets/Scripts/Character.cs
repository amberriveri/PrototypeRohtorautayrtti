using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Character : MonoBehaviour, IMove
{
    //SerializeField shows field in Inspector, even though it's protected
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float moveSpeed = 5f;
    protected Vector2 moveDirection;
    protected Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) Debug.Log("No rigidbody on character.");

        animator = GetComponent<Animator>();

        // you can't fall or spin
        rb.freezeRotation = true;
        rb.gravityScale = 0;
    }

    //inheriting classes must override
    public abstract void Move();

    protected virtual void FixedUpdate()
    {
        rb.linearVelocity = moveDirection * moveSpeed;
    }
}
