using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script05 : MonoBehaviour
{
    [SerializeField] private int startNum;
    [SerializeField] private int endNum;

    void Start()
    {
        CalOneToTen();
    }

    void CalOneToTen()
    {
        int r_num = 0;

        for (int i = startNum; i < endNum + 1; i++)
        {
            r_num += i;
        }

        Debug.Log(startNum + "부터 "+ endNum +"까지의 합은 : " + r_num);
    }
}
