using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawn : MonoBehaviour
{
    [SerializeField] private GameObject healthPack;
    private GameObject player;
    private float defaultFloatHeight = 0.5f;
    private int SpawnCount;
    private float lastspawnTime;
    private float deltaTime = 15f;
    private GameObject lastSpawnedHealthPack;
    [SerializeField] Terrain landscape;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerArmature");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(landscape.SampleHeight(player.GetComponent<Transform>().position) + landscape.transform.position.y);
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health.currentHealth < 50)
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
        randomPos.y = landscape.SampleHeight(transform.position) + landscape.transform.position.y;
        SpawnCount++;
        return randomPos;
    }
    
}
