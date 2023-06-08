using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public int playerNum = 1;
    string mvAxisName;
    string rotAxisName;

    private float tkMySpeed = 10.0f;
    private float tkRotSpeed = 150.0f;

    public Color tankColor;

    private void Start()
    {
        mvAxisName = "Vertical" + playerNum;
        rotAxisName = "Horizontal" + playerNum;

        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        for(int i =0; i<renderers.Length; i++)
        {
            renderers[i].material.color = tankColor;
        }
    }
    void Update()
    {
        float mv = Input.GetAxis(mvAxisName) * tkMySpeed * Time.deltaTime;
        float rot = Input.GetAxis(rotAxisName) * tkRotSpeed * Time.deltaTime;

        transform.Translate(0, 0, mv);
        transform.Rotate(0, rot, 0);
    }
}
