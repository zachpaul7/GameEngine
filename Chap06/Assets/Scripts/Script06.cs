using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script06 : MonoBehaviour
{
    [SerializeField] private float inch;
    float cm;

    void Start()
    {
        InchToCm(inch);
    }

    void InchToCm(float inch)
    {
        cm = inch * 2.54f;

        Debug.Log("��ġ : " + inch + "in");
        Debug.Log("��Ƽ : " + cm + "cm");
    }
}
