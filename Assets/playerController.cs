using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển
    public float rotationSpeed = 720f; // Tốc độ xoay (độ/giây)
    public Rigidbody playerRigidbody; // Gắn Rigidbody của nhân vật

    private Vector3 movementInput; // Vector lưu hướng di chuyển

    void Update()
    {
        // Nhận input từ bàn phím
        float horizontal = Input.GetAxis("Horizontal"); // Phím A/D hoặc mũi tên trái/phải
        float vertical = Input.GetAxis("Vertical");     // Phím W/S hoặc mũi tên lên/xuống

        // Tạo vector hướng di chuyển
        movementInput = new Vector3(horizontal, 0f, vertical).normalized;

        // Xoay nhân vật dựa trên hướng di chuyển (nếu có)
        if (movementInput != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementInput);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    void FixedUpdate()
    {
        // Di chuyển nhân vật
        Vector3 moveDirection = movementInput * moveSpeed * Time.fixedDeltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + moveDirection);
    }
}
