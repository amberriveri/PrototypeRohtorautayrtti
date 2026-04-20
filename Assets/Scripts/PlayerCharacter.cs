using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerCharacter : Character
{
    [SerializeField] InputActionReference moveAction;

    public override void Move()
    {
        //reference to Input System action used for movement, assignable from Inspector
        moveDirection = moveAction.action.ReadValue<Vector2>().normalized;

        if (moveDirection.sqrMagnitude < 0.001f)
        {
            moveDirection = Vector2.zero;

            animator.SetBool("isWalking", false);

            animator.SetFloat("LastInputX", animator.GetFloat("InputX"));
            animator.SetFloat("LastInputY", animator.GetFloat("InputY"));

            animator.SetFloat("InputX", 0f);
            animator.SetFloat("InputY", 0f);

            return;
        }

        animator.SetBool("isWalking", true);
        animator.SetFloat("InputX", moveDirection.x);
        animator.SetFloat("InputY", moveDirection.y);
    }

    public void OnDogFoundMe()
    {
        Debug.Log("Dog found the player");
    }
}
