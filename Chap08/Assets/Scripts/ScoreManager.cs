using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text score;
    public int count;

    void Start()
    {
        this.score = GameObject.Find("Score").GetComponent<Text>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InScore()
    {
        count += 1;
        this.score.text = count.ToString();
    }
}
