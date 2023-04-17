using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody bulletBody;
    [SerializeField] float bulletSpeed;
    [SerializeField] private Transform vfxcollision;

    private int damage = -25;

    private void Awake()
    {
        bulletBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        bulletBody.velocity = transform.forward * bulletSpeed;

    }
    private void OnTriggerEnter(Collider otherBody)
    {
        Destroy(gameObject);
        Instantiate(vfxcollision, transform.position, Quaternion.identity);
        if (otherBody.gameObject.tag == "Enemy")
        {
            EnemyHealth eHealth = otherBody.GetComponent<EnemyHealth>();
            eHealth.AdjustCurrentHealth(damage);
        }
        Destroy(this.gameObject);
    }
}
