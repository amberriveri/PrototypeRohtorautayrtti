using UnityEngine;

public class Player : Creature
{
    public override Vector2 GetMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
       
        return new Vector2(x,y);
    }
}
