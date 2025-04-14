using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ARShoot : MonoBehaviour
{
    public InputActionReference tapAction;
    public GameObject bulletPrefab;

    private float speed = 4;

/*    private void OnEnable()
    {
        tapAction.action.Enable();
        tapAction.action.performed += OnTapDetected;
    }

    private void OnDisable()
    {
        tapAction.action.Disable();
        tapAction.action.performed -= OnTapDetected;
    }*/

    /*void OnTapDetected(InputAction.CallbackContext ctx)
    {
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = transform.position;
        newBullet.GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;
    }*/

    public void ShootWithPrefab(GameObject prefab)
    {
        GameObject newBullet = Instantiate(prefab);
        newBullet.transform.position = transform.position;
        newBullet.GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;
    }
}
