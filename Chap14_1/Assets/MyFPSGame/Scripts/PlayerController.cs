using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float mvSpeed = 10.0f;
    private Quaternion m_CharacterTargetRot;
    private Quaternion m_CameraTargetRot;
    private Camera m_Camera;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
        m_CharacterTargetRot = transform.localRotation;
        m_CameraTargetRot = m_Camera.transform.localRotation;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xRot = Input.GetAxis("Mouse Y");
        float yRot = Input.GetAxis("Mouse X");

        m_CharacterTargetRot *= Quaternion.Euler(0, yRot, 0);
        transform.localRotation = m_CharacterTargetRot;

        m_CameraTargetRot *= Quaternion.Euler(xRot, 0, 0);
        m_Camera.transform.localRotation = m_CameraTargetRot;

        float vmv = Input.GetAxis("Vertical");
        float hmv = Input.GetAxis("Horizontal");

        Vector2 m_Input = new Vector2(hmv, vmv);
        Vector3 desiredMove = transform.forward * -1 * m_Input.y + transform.right * -1 * m_Input.x;
        transform.position += desiredMove * mvSpeed * Time.deltaTime;
    }
}
