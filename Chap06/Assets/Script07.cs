using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InchToCm
{
    public float inch;
    public float cm;

    public void Convert(float inch)
    {
        cm = inch * 2.54f;

        Debug.Log("인치 : " + inch + "in");
        Debug.Log("센티 : " + cm + "cm");
    }
}

public class Script07 : MonoBehaviour
{
    [SerializeField] private float inch;

    void Start()
    {
        InchToCm inchToCm = new InchToCm();

        inchToCm.inch = this.inch;
        inchToCm.Convert(inchToCm.inch);
    }
}
