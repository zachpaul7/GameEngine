using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    GameObject player;
    private GameObject ec;

    [SerializeField] private AudioClip DestroySE;
    private AudioSource aud;

    [SerializeField] private ParticleSystem turretExplosion;

    BoxCollider boxCollider;

    GameObject ehp;
    GameObject canv;
    GameObject hp;

    // Start is called before the first frame update
    void Start()
    {
        ehp = gameObject.transform.GetChild(0).gameObject;
        canv = ehp.transform.GetChild(0).gameObject;
        hp = canv.transform.GetChild(1).gameObject;

        player = GameObject.Find("Player");
        aud = GetComponent<AudioSource>();
        ec = GameObject.Find("EnemyCounter");
        boxCollider = GetComponent<BoxCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir, Vector3.up);
        Vector3 rotationEulerAngles = lookRotation.eulerAngles;
        rotationEulerAngles.x = 0;
        rotationEulerAngles.z = 0;
        transform.rotation = Quaternion.Euler(rotationEulerAngles);

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "BULLET")
        {

            if (hp.GetComponent<Image>().fillAmount > 0f)
            {
                hp.GetComponent<Image>().fillAmount -= 0.5f;
            }
            else if (hp.GetComponent<Image>().fillAmount <= 0f)
            {
                boxCollider.enabled = false;
                Destroy(gameObject, 1.3f);
                aud.PlayOneShot(DestroySE);
                ParticleSystem explosion = Instantiate(turretExplosion, transform.position, Quaternion.identity,transform);
                explosion.Play();
                Destroy(explosion.gameObject, 0.5f);
                ec.GetComponent<EnemyCount>().CountEnemy();
            }
        }

    }
}
