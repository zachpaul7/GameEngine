using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private EnemyCount ec;

    private GameObject ehp;
    private GameObject canv;
    private GameObject hp;
    private int eCounter;
    private float timer;

    private void Start()
    {
        ehp = GameObject.Find("Canvas");
        canv = ehp.transform.GetChild(1).gameObject;
        hp = canv.transform.GetChild(1).gameObject;
        timer = 30f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EBullet")
        {
            if (hp.GetComponent<Image>().fillAmount > 0f)
            {
                hp.GetComponent<Image>().fillAmount -= 0.2f;
            }
            else if (hp.GetComponent<Image>().fillAmount <= 0f)
            {
                hp.GetComponent<Image>().fillAmount = 0f;
            }
        }
    }

    private void Update()
    {
        if (timer != 0f)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = 0;
            }
        }
        
        int t = Mathf.FloorToInt(timer);
        timerText.text = "Time : " + t.ToString();
    }

    private void FixedUpdate()
    {
        eCounter = ec.eCount;
        if (eCounter == 0 && timer > 0)
        {
            SceneManager.LoadScene("WinScene");
        }

        else if (hp.GetComponent<Image>().fillAmount < 0.2f || timer == 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
