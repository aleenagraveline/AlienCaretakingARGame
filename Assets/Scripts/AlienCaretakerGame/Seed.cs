using TMPro;
using UnityEngine;

public class Seed : MonoBehaviour
{
    private float timer;
    private bool readyToHarvest;
    [SerializeField] private float growthTime;
    private Vector3 seedlingScale;
    private Vector3 fullyGrownScale;
    private float growthSpeed;
    private float startTime;
    private float totalAmountToGrow;
    [SerializeField] private TextMeshPro guideText;
    [SerializeField] private InventoryManagement inventoryManager;
    private string name;

    void Start()
    {
        if(growthTime == 10)
        {
            name = "Cube: ";
        }
        else if(growthTime == 20)
        {
            name = "Cylinder: ";
        }
        else
        {
            name = "Capsule: ";
        }

        timer = growthTime;
        readyToHarvest = false;
        seedlingScale = this.transform.localScale;
        fullyGrownScale = new Vector3(1, 1, 1);
        growthSpeed = 1/growthTime;
        startTime = Time.time;
        totalAmountToGrow = Vector3.Distance(seedlingScale, fullyGrownScale);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            readyToHarvest = true;
            guideText.SetText(name + "Ready to harvest!");
        }

        if(!readyToHarvest)
        {
            float amountGrown = (Time.time - startTime) * growthSpeed;
            float fractionGrown = amountGrown / totalAmountToGrow;
            this.transform.localScale = Vector3.Lerp(seedlingScale, fullyGrownScale, fractionGrown);
            guideText.SetText(name + timer.ToString("F0") + " seconds remaining");
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.localScale.y / 2, this.transform.position.z);
        }
    }

    public void Plant()
    {
        if (!(this.gameObject.activeSelf))
        {
            Start();
            this.gameObject.SetActive(true);
        }
    }

    public void Harvest()
    {
        if(readyToHarvest)
        {
            this.gameObject.SetActive(false);
            guideText.SetText(name + "(Plant me!)");
            readyToHarvest = false;

            if(growthTime == 10)
            {
                inventoryManager.AddPlant("cube");
            }
            else if(growthTime == 20)
            {
                inventoryManager.AddPlant("cylinder");
            }
            else
            {
                inventoryManager.AddPlant("capsule");
            }
        }
    }
}
