using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    Transform target;
    public GameObject bulletPrefab;
    public float shootRange = 10f;
    public float fireRate = 1f;

    private float nextFireTime;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (target == null)
        {

            return;
        }

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= shootRange && Time.time >= nextFireTime)
        {

            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        bullet.transform.LookAt(target);

        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 50f, ForceMode.Impulse);
    }
}
