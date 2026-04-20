using UnityEngine;

[CreateAssetMenu(fileName = "PurpleFlower", menuName = "Plants/PurpleFlower")]
public class PurpleFlower : PlantType
{
    public override void OnHarvest(Inventory inventory)
    {
        inventory.AddPlant(this, 1);
        Debug.Log("Harvested purple flower");
    }
}
