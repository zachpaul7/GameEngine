using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject player;
    GameObject enemy;

    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Vector3 dir;
            dir = player.transform.position - enemy.transform.position;
            bullet.GetComponent<BulletController>().Shoot(dir * 50);
        }
    }
}
