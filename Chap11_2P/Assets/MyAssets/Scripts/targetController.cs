using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetController : MonoBehaviour
{
    public ParticleSystem targetExplosion;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "SHELL")
        {
            ParticleSystem fire = Instantiate(targetExplosion, transform.position, Quaternion.identity);
            fire.Play();

            Destroy(gameObject);

            Destroy(fire.gameObject, 2.0f);
        }
    }
}
