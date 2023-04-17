using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawn : MonoBehaviour
{
    [SerializeField] private GameObject healthPack;
    private GameObject player;
    private float defaultFloatHeight = 1f;
    private int SpawnCount;
    private float lastspawnTime;
    private float deltaTime = 15f;
    private GameObject lastSpawnedHealthPack;
    [SerializeField] Terrain landscape;
    private PlayerHealth health;
    private PlayerInventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerArmature");
        health = player.GetComponent<PlayerHealth>();
        inventory = player.GetComponent<PlayerInventory>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(landscape.SampleHeight(player.GetComponent<Transform>().position) + landscape.transform.position.y);
        
        if (health.currentHealth < 50 && inventory.healthPacksCollected == 0)
        {
            if(Time.time > lastspawnTime + deltaTime)
            {
                if (lastSpawnedHealthPack)
                {
                    Destroy(lastSpawnedHealthPack);
                }
                Vector3 newSpawnPoint = generateHealthPackSpawnPoint();
                lastSpawnedHealthPack = Instantiate(healthPack, newSpawnPoint, Quaternion.identity);
                lastspawnTime = Time.time;
            }
        }
    }

    private Vector3 generateHealthPackSpawnPoint()
    {
        var randomPos = (Vector3)Random.insideUnitCircle * 4;
        randomPos += player.GetComponent<Transform>().position;
        randomPos.y = landscape.SampleHeight(randomPos) + landscape.transform.position.y + defaultFloatHeight;
        SpawnCount++;
        return randomPos;
    }
    
}
