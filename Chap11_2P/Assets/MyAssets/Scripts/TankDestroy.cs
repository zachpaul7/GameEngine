using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDestroy : MonoBehaviour
{
    public ParticleSystem targetExplosion;
    public GameObject bustTank;
    private int count = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SHELL")
        {
            count++;
            if(count >= 2)
            {
                ParticleSystem fire = Instantiate(targetExplosion, transform.position, Quaternion.identity);
                fire.Play();

                Destroy(gameObject);
                Instantiate(bustTank, transform.position, Quaternion.identity);
                Destroy(fire.gameObject, 2.0f);
            }
        }
    }
}
