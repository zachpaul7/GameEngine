using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyCount : MonoBehaviour
{
    [HideInInspector] public int eCount;
    [SerializeField] Text eCountText;

    void Start()
    {
        eCount = 5;
        eCountText.text = eCount.ToString();
    }

    public void CountEnemy()
    {
        eCount--;
        eCountText.text = eCount.ToString();
        Debug.Log("eCount = " + eCount);
        
    }
}
