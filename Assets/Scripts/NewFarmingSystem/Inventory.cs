using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<PlantType, int> plants = new Dictionary<PlantType, int>();

    public void AddPlant(PlantType plant, int amount)
    {
        if (plants.ContainsKey(plant))
        {
            plants[plant] += amount;
        }
        else
        {
            plants[plant] = amount;
        }

        Debug.Log($"{plant.plantName} added. Total: {plants[plant]}");
    }

    public int GetAmount(PlantType plant)
    {
        if (plants.TryGetValue(plant, out int amount))
        {
            return amount;
        }
        return 0;
    }
}
