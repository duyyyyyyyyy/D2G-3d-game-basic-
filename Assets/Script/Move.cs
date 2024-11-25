using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 Movement;
    [SerializeField]
    private float MovementSpeed = 5f;
    private float horizontal, vertical;
    [SerializeField]
    private CharacterController characterController;
    public Camera playercam;
    [SerializeField]
    float sensitivity = 2f; // do nhay chuot
    float rotationX = 0f; //goc xoay theo truc x

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Movement = transform.right * horizontal + transform.forward * vertical;
        transform.position += Movement * MovementSpeed * Time.deltaTime;

        //dieu khien cam theo chuot
        float inputX = Input.GetAxis("Mouse X");
        float inputY = Input.GetAxis("Mouse Y");

        rotationX -= inputY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90);//gioi han truc x (len/xuong)

        playercam.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.Rotate(Vector3.up * inputX);//xoay theo truc y
    }
}
