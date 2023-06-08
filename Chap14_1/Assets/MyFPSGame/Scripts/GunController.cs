using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Rigidbody prefabBullet;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private AudioClip fireSE;
    AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            Fire();
            aud.PlayOneShot(fireSE);
        }
    }

    private void Fire()
    {
        Rigidbody bulletInstance = Instantiate(prefabBullet, fireTransform.position, fireTransform.rotation) as Rigidbody;

        bulletInstance.velocity = 30.0f * fireTransform.forward;
    }
}
