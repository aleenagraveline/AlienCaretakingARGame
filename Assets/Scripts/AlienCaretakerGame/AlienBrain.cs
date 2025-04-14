using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlienBrain : MonoBehaviour
{
    [SerializeField] private InventoryManagement inventoryManager;
    [SerializeField] private GameObject alien;
    private int happiness;
    private int demand;
    private float timeToMeetDemand;
    private float timer;

    private Color cubeColor = new Color(0.1618582f, 0.1721459f, 0.6754716f);
    private Color cylinderColor = new Color(0.5019935f, 0.9018868f, 0.8341284f);
    private Color capsuleColor = new Color(0.3758777f, 0.05834807f, 0.5622641f);

    [SerializeField] private RawImage demandSymbol;
    [SerializeField] private TextMeshProUGUI demandText;
    [SerializeField] private GameObject madIndicator;
    [SerializeField] private GameObject mehIndicator;
    [SerializeField] private GameObject happyIndicator;
    [SerializeField] private TextMeshPro ranAwayText;

    void Start()
    {
        happiness = 2;
        SelectDemand();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        demandText.SetText("TIME REMAINING: " + timer.ToString("F0"));

        if(timer <= 0)
        {
            timer = 0;
            if (demand == 1)
            {
                int numCubes = inventoryManager.GetCurrentInventory("cube");
                if (numCubes <= 0)
                {
                    happiness--;
                }
                else
                {
                    if (happiness < 3)
                    {
                        happiness++;
                    }
                    inventoryManager.EatPlant("cube");
                }
            }
            else if (demand == 2)
            {
                int numCylinders = inventoryManager.GetCurrentInventory("cylinder");
                if (numCylinders <= 0)
                {
                    happiness--;
                }
                else
                {
                    if (happiness < 3)
                    {
                        happiness++;
                    }
                    inventoryManager.EatPlant("cylinder");
                }
            }
            else
            {
                int numCapsules = inventoryManager.GetCurrentInventory("capsule");
                if(numCapsules <= 0)
                {
                    happiness--;
                }
                else
                {
                    if(happiness < 3)
                    { 
                        happiness++;
                    }
                    inventoryManager.EatPlant("capsule");
                }
            }

            if(happiness > 0)
            {
                SelectDemand();
                if(happiness == 1)
                {
                    madIndicator.SetActive(true);
                    mehIndicator.SetActive(false);
                }
                else if(happiness == 2)
                {
                    mehIndicator.SetActive(true);
                    happyIndicator.SetActive(false);
                    madIndicator.SetActive(false);
                }
                else
                {
                    happyIndicator.SetActive(true);
                    mehIndicator.SetActive(false);
                }
            }
            else
            {
                Destroy(alien);
                ranAwayText.gameObject.SetActive(true);
            }
        }
    }

    private void SelectDemand()
    {
        demand = Random.Range(1, 4); 
        if(demand == 1)
        {
            timeToMeetDemand = 15;
            demandSymbol.color = cubeColor;
        }
        else if(demand == 2)
        {
            timeToMeetDemand = 25;
            demandSymbol.color = cylinderColor;
        }
        else
        {
            timeToMeetDemand = 35;
            demandSymbol.color = capsuleColor;
        }
        timer = timeToMeetDemand;
    }
}
