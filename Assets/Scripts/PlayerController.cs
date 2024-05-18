using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public Transform m_camera;

    [SerializeField] float speed;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Physics.gravity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 m_input = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 direction = m_camera.forward;
        if (m_input.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
