using UnityEngine;

[CreateAssetMenu(fileName = "YellowFlower", menuName = "Plants/YellowFlower")]
public class YellowFlower : PlantType
{
    public override void OnHarvest(Inventory inventory)
    {
        inventory.AddPlant(this, 2);
        Debug.Log("Harvested yellow flower");
    }
}
