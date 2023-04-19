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

        Debug.Log("인치 : " + inch + "in");
        Debug.Log("센티 : " + cm + "cm");
    }
}
