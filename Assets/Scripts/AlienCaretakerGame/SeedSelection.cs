using UnityEngine;

public class SeedSelection : MonoBehaviour
{
    [SerializeField] private Seed cubeSeed;
    [SerializeField] private Seed cylinderSeed;
    [SerializeField] private Seed capsuleSeed;

    private Seed selected;

    public void SelectSeed(Seed seedToSelect)
    {
        selected = seedToSelect;
    }

    public void PlantSelected()
    {
        if(selected != null)
        {
            if (selected == cubeSeed)
            {
                cubeSeed.Plant();
            }
            else if (selected == cylinderSeed)
            {
                cylinderSeed.Plant();
            }
            else
            {
                capsuleSeed.Plant();
            }
        }
    }

    public void HarvestSelected()
    {
        if(selected != null)
        {
            if (selected == cubeSeed)
            {
                cubeSeed.Harvest();
            }
            else if (selected == cylinderSeed)
            {
                cylinderSeed.Harvest();
            }
            else
            {
                capsuleSeed.Harvest();
            }
        }
    }
}
