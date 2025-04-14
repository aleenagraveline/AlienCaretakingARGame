using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Vector3 targetPos = Vector3.zero;
    public float speed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToTarget = targetPos - transform.position;

        if(vectorToTarget.magnitude < speed * Time.deltaTime)
        {
            transform.position = targetPos;
        }

        transform.position += vectorToTarget.normalized * speed * Time.deltaTime;
    }
}
