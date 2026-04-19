using UnityEngine;

public class DogCharacter : Character
{
    public Transform player;
    public float followDistance = 1.5f;

    SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //auto-find player if not assigned
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");

            if (playerObj != null)
            {
                player = playerObj.transform;

                PlayerCharacter playerCharacter = playerObj.GetComponent<PlayerCharacter>();
                
                if (playerCharacter != null)
                {
                    playerCharacter.OnDogFoundMe();
                }
            }
            else
            {
                Debug.LogWarning("Dog could not find a player with tag 'Player'");
            }
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Move();
    }

    public override void Move()
    {
        if (player == null) return;

        moveDirection = player.position - transform.position;
        float distance = moveDirection.magnitude;

        if (distance <= followDistance)
        {
            moveDirection = Vector3.zero;
            animator.SetBool("isWalking", false);
            return;
        }

        moveDirection = moveDirection.normalized;
        animator.SetBool("isWalking", true);

        if (Mathf.Abs(moveDirection.x) > 0.01f)
        {
            spriteRenderer.flipX = moveDirection.x < 0f;
        }
    }
}
