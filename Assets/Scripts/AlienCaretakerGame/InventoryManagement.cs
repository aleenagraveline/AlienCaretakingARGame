using TMPro;
using UnityEngine;

public class InventoryManagement : MonoBehaviour
{
    private int numCubes;
    private int numCylinders;
    private int numCapsules;

    [SerializeField] private TextMeshProUGUI cubesText;
    [SerializeField] private TextMeshProUGUI cylindersText;
    [SerializeField] private TextMeshProUGUI capsulesText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numCubes = 0;
        numCylinders = 0;
        numCapsules = 0;
    }

    public void AddPlant(string name)
    {
        if(name.Equals("cube"))
        {
            numCubes++;
            cubesText.SetText("Cubes: " + numCubes);
        }
        else if(name.Equals("cylinder"))
        {
            numCylinders++;
            cylindersText.SetText("Cylinders: " + numCylinders);
        }
        else
        {
            numCapsules++;
            capsulesText.SetText("Capsules: " + numCapsules);
        }
    }

    public void EatPlant(string name)
    {
        if (name.Equals("cube"))
        {
            numCubes--;
            cubesText.SetText("Cubes: " + numCubes);
        }
        else if (name.Equals("cylinder"))
        {
            numCylinders--;
            cylindersText.SetText("Cylinders: " + numCylinders);
        }
        else
        {
            numCapsules--;
            capsulesText.SetText("Capsules: " + numCapsules);
        }
    }

    public int GetCurrentInventory(string name)
    {
        if (name.Equals("cube"))
        {
            return numCubes;
        }
        else if (name.Equals("cylinder"))
        {
            return numCylinders;
        }
        else
        {
            return numCapsules;
        }
    }
}
