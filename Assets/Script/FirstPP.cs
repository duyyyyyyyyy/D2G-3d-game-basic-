using UnityEngine;

public class FirtsPP : MonoBehaviour
{
    public Transform player;
    public float mouseSensitity = 2f;
    float cameraVerticalRotation = 0f;
    bool lockedCursor = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //khoa va an con tro chuot
        Cursor.visible = false;
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //chon con tro
        float inputX = Input.GetAxis("Mouse X")*mouseSensitity;
        float inputY = Input.GetAxis("Mouse Y")*mouseSensitity;
        //di chuyen cam theo truc x
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f,90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        //di chuyen cam theo truc y
        player.Rotate(Vector3.up * inputX);
    }
}
