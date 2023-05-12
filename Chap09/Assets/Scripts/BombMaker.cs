using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMaker : MonoBehaviour
{
    public GameObject bmPrefab;
    private float interval = 1.0f;
    private float delta = 0;

    private void Update()
    {
        delta += Time.deltaTime;
        if(delta > interval)
        {
            delta = 0;
            GameObject bomb = Instantiate(bmPrefab);
            int x = Random.Range(-5, 5);
            bomb.transform.position = new Vector3(x, 6, 0); 
        }
    }
}
