using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Dog : Creature
{
    public Transform player;
    public float followDistance = 1.5f;
    public float dogSpeed = 2f;         

    protected override void Awake()
    {
        base.Awake();

        speed = dogSpeed;

        //auto-find player if not assigned
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
            else
                Debug.LogWarning("Dog could not find a player with tag 'Player'");
        }
    }

    public override Vector2 GetMovement()
    {
        if (player == null) return Vector2.zero;

        Vector2 direction = player.position - transform.position;
        float distance = direction.magnitude;

        if (distance <= followDistance)
            return Vector2.zero;

        return direction.normalized;
    }
}