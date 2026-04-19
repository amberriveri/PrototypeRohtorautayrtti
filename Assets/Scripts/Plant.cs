using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject seed;
    [SerializeField] private GameObject flower;
    [SerializeField] private float waitingTime = 5f;
    [SerializeField] private KeyCode plantKey = KeyCode.E;
    [SerializeField] private bool isInPlantArea;
    [SerializeField] private bool isActive;
    [SerializeField] private bool canPlant;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canPlant = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInPlantArea && Input.GetKeyDown(plantKey) && !isActive && canPlant)
        {
            PlantSeed();
            canPlant = false;
        }
        if (isInPlantArea && Input.GetKeyDown(plantKey) && isActive)
        {
            Harvest();
        }
    }

    public void PlantSeed()
    {
        seed.SetActive(true);
        Debug.Log("Seed planted.");
        StartCoroutine(PlantingCoroutine());
    }
    private IEnumerator PlantingCoroutine()
    {
        isActive = true;
        yield return new WaitForSeconds(waitingTime);
        seed.SetActive(false);
        flower.SetActive(true);
        Debug.Log("Plant has grown.");
    }

    public void Harvest()
    {
        if (flower.activeSelf)
        {
            flower.SetActive(false);
            canPlant = true;
            isActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInPlantArea = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInPlantArea = false;
        }
    }
}
