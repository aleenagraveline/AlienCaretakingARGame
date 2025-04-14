using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    private float spawnRate = 3;
    private float spawnCountdown;
    private float distFromCenter = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnCountdown = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnCountdown < 0)
        {
            GameObject newEnemy = Instantiate(enemy);

            Vector2 spawnPosition = Random.insideUnitCircle.normalized * distFromCenter;
            newEnemy.transform.position = new Vector3(spawnPosition.x, 0, spawnPosition.y);
            spawnCountdown = spawnRate;
        }

        spawnCountdown -= Time.deltaTime;
    }
}
