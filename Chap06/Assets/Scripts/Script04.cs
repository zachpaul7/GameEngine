using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script04 : MonoBehaviour
{
    [SerializeField] private int num;

    void Start()
    {
        Numif(num);
    }

    void Numif(int num)
    {
        if (num > 80)
        {
            Debug.Log("���");
        }
        else if (num > 60)
        {
            Debug.Log("����");
        }
        else
        {
            Debug.Log("����");
        }
    }
}
