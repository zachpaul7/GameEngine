using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script02 : MonoBehaviour
{
    float inch = 70;
    float cm;

    void Start()
    {
        cm = inch * 2.54f;

        Debug.Log("��ġ : " + inch + "in");
        Debug.Log("��Ƽ : " + cm + "cm");
    }
}
