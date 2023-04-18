using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody bulletBody;
    [SerializeField] float bulletSpeed;
    [SerializeField] private Transform vfxcollision;
    private Terrain landscape;
    private PlayerScore playerScore;

    private int damage = -25;
    private PopupMessage messageScript;

    private void Awake()
    {
        bulletBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        bulletBody.velocity = transform.forward * bulletSpeed;
        landscape = GameObject.Find("Terrain").GetComponent<Terrain>();
        messageScript = GameObject.Find("Popup").GetComponent<PopupMessage>();
        playerScore = GameObject.Find("PlayerArmature").GetComponent<PlayerScore>();

    }
    private void OnTriggerEnter(Collider otherBody)
    {
        Instantiate(vfxcollision, transform.position, Quaternion.identity);
        if (otherBody.gameObject.tag == "Enemy")
        {
            EnemyHealth eHealth = otherBody.GetComponent<EnemyHealth>();
            eHealth.AdjustCurrentHealth(damage);
            Vector3 bulletCoordinate = gameObject.transform.position;
            Vector3 terrainCoordinate = bulletCoordinate;

            terrainCoordinate.y = landscape.SampleHeight(bulletCoordinate) + landscape.transform.position.y;
            ShotType(bulletCoordinate, terrainCoordinate);
        }
        Destroy(gameObject);
        // Destroy(this.gameObject);
    }

    private void ShotType(Vector3 bullet, Vector3 terrain)
    {
        if (bullet.y - terrain.y >= 1.25)
        {
            playerScore.Headshot();
        }
        else
        {
            playerScore.Bodyshot();
        }
    }
}
