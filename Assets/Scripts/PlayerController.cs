using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] Transform m_camera;
    [SerializeField] float speed;

    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Physics.gravity = Vector3.zero;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
#if UNITY_EDITOR
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 inputJoystick = new Vector3 (horizontal, 0, vertical);
#else
        Vector3 inputJoystick = MainSceneMgr.Instance.GetInputManager().moveInput;
#endif

        Vector3 dir = (horizontal * m_camera.right + vertical * m_camera.forward).normalized;
        Vector3 m_input = new Vector3(horizontal, 0, vertical).normalized;
        if (m_input.magnitude >= 0.1f)
        {
            controller.Move(dir * speed * Time.deltaTime);
        }
    }
}
