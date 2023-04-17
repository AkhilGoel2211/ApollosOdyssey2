using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AmmoSpawn : MonoBehaviour
{
    [SerializeField] GameObject ammoBox;
    private GameObject player;
    private float defaultFloatHeight = 1f;
    private float lastspawnTime;
    private float deltaTime = 25f;
    [SerializeField] Terrain landscape;
    private PlayerInventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerArmature");
        inventory = player.GetComponent<PlayerInventory>();

    }

    // Update is called once per frame
    void Update()
    {
          if(Time.time > lastspawnTime + deltaTime)
        {
            Vector3 newSpawnPoint = generateHealthPackSpawnPoint();
            Instantiate(ammoBox, newSpawnPoint, Quaternion.identity);
            lastspawnTime = Time.time;
        }
    }

    private Vector3 generateHealthPackSpawnPoint()
    {
        var randomPos = (Vector3)Random.insideUnitCircle * 5;
        randomPos += player.GetComponent<Transform>().position;
        randomPos.y = landscape.SampleHeight(randomPos) + landscape.transform.position.y + defaultFloatHeight;
        return randomPos;
    }

}
