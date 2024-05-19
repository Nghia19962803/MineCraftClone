using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Common;
using CW.Common;
using Lean.Touch;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform m_camera;
    float xRotation = 0;

    public LeanFingerFilter Use = new LeanFingerFilter(true);
    public LeanScreenDepth ScreenDepth = new LeanScreenDepth(LeanScreenDepth.ConversionType.DepthIntercept);
    [SerializeField]
    private Vector3 remainingDelta;

    public float Damping { set { damping = value; } get { return damping; } }
    [SerializeField] private float damping = -1.0f;
    public float Inertia { set { inertia = value; } get { return inertia; } }
    [SerializeField][Range(0.0f, 1.0f)] private float inertia;


    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    float mouseX = Input.GetAxis("MouseX") * mouseSensitivity * Time.deltaTime;
    //    float mouseY = Input.GetAxis("MouseY") * mouseSensitivity * Time.deltaTime;

    //    xRotation -= mouseY;
    //    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    //    m_camera.localRotation = Quaternion.Euler(xRotation, 0, 0);
    //    transform.Rotate(Vector3.up * mouseX);
    //}

    private void LateUpdate()
    {
        var fingers = Use.UpdateAndGetFingers();
        var lastScreenPoint = LeanGesture.GetLastScreenCenter(fingers);
        var screenPoint = LeanGesture.GetScreenCenter(fingers);

        // Get the world delta of them after conversion
        var worldDelta = ScreenDepth.ConvertDelta(lastScreenPoint, screenPoint, m_camera.gameObject);
        Vector3 aaa = new Vector3(-worldDelta.y, worldDelta.x, 0);
        // Store the current position
        var oldPosition = m_camera.localEulerAngles;

        // Pan the camera based on the world delta
        m_camera.localEulerAngles += aaa;

        remainingDelta += m_camera.localEulerAngles - oldPosition;

        // Get t value
        var factor = CwHelper.DampenFactor(damping, Time.deltaTime);

        // Dampen remainingDelta
        var newRemainingDelta = Vector3.Lerp(remainingDelta, Vector3.zero, factor);

        // Shift this position by the change in delta
        //transform.localEulerAngles = oldPosition + remainingDelta - newRemainingDelta;

        if (fingers.Count == 0 && inertia > 0.0f && damping > 0.0f)
        {
            newRemainingDelta = Vector3.Lerp(newRemainingDelta, remainingDelta, inertia);
        }

        // Update remainingDelta with the dampened value
        remainingDelta = newRemainingDelta;
    }
}
