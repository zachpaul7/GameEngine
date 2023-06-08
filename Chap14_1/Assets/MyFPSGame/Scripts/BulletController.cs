using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    [SerializeField] private ParticleSystem bulletExplosion;


    private void OnCollisionEnter(Collision collision)
    {
        ParticleSystem fire = Instantiate(bulletExplosion, transform.position, Quaternion.identity,transform);
        fire.Play();
        Destroy(fire.gameObject,0.5f);
        Destroy(gameObject);
        
    }
}
