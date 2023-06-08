using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    private float tkMySpeed = 10.0f;
    private float tkRotSpeed = 150.0f;

    void Update()
    {
        float mv = Input.GetAxis("Vertical1") * tkMySpeed * Time.deltaTime;
        float rot = Input.GetAxis("Horizontal1") * tkRotSpeed * Time.deltaTime;

        transform.Translate(0, 0, mv);
        transform.Rotate(0, rot, 0);
    }
}
