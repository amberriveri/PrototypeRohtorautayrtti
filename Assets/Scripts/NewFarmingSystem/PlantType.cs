using UnityEngine;

//container for shared data
public abstract class PlantType : ScriptableObject
{
    public string plantName;
    public Sprite seedSprite;
    public Sprite flowerSprite;
    public float growTime = 5f;

    public abstract void OnHarvest(Inventory inventory);
}
