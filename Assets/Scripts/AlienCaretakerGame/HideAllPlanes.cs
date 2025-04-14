using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class HideAllPlanes : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;

    public void HideARPlanes()
    {
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
    }
}
