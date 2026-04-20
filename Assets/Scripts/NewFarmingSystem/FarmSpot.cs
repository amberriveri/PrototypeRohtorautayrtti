using System.Collections;
using UnityEngine;

public class FarmSpot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer seedRenderer;
    [SerializeField] private SpriteRenderer flowerRenderer;

    [SerializeField] private PlantType[] plants;
    [SerializeField] private Inventory inventory;

    [SerializeField] private KeyCode plantKey = KeyCode.E;

    [SerializeField] private bool isInPlantArea;
    [SerializeField] private bool isActive;
    [SerializeField] private bool isGrown;
    [SerializeField] private bool canPlant = true;

    private PlantType currentPlant;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        seedRenderer.gameObject.SetActive(false);
        flowerRenderer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (isInPlantArea && Input.GetKeyDown(plantKey) && canPlant && !isActive)
        {
            PlantRandom();
        }
        else if (isInPlantArea && Input.GetKeyDown(plantKey) && isGrown)
        {
            Harvest();
        }
    }

    private void PlantRandom()
    {
        if (plants == null || plants.Length == 0)
        {
            Debug.LogWarning("No possible plants assigned.");
            return;
        }

        int index = Random.Range(0, plants.Length);
        PlantType chosenPlant = plants[index];
        PlantSeed(chosenPlant);
    }

    private void PlantSeed(PlantType plant)
    {
        currentPlant = plant;
        isActive = true;
        isGrown = false;
        canPlant = false;

        seedRenderer.sprite = currentPlant.seedSprite;
        flowerRenderer.sprite = currentPlant.flowerSprite;

        seedRenderer.gameObject.SetActive(true);
        flowerRenderer.gameObject.SetActive(false);

        StartCoroutine(GrowPlant());
    }

    private IEnumerator GrowPlant()
    {
        yield return new WaitForSeconds(currentPlant.growTime);

        seedRenderer.gameObject.SetActive(false);
        flowerRenderer.gameObject.SetActive(true);
        isGrown = true;
    }

    private void Harvest()
    {
        if (currentPlant == null) return;

        currentPlant.OnHarvest(inventory);

        flowerRenderer.gameObject.SetActive(false);

        currentPlant = null;
        isActive = false;
        isGrown = false;
        canPlant= true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInPlantArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInPlantArea = false;
        }
    }
}
