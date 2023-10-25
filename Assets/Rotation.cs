using UnityEngine;

public class MoveBetweenPositions : MonoBehaviour
{
    public Transform leftPosition; // Transform posisi kiri
    public Transform rightPosition; // Transform posisi kanan
    public float moveSpeed = 5.0f; // Kecepatan perpindahan objek

    private Transform targetPosition; // Posisi target (kiri atau kanan)

    private void Start()
    {
        // Mulai dengan mengatur posisi awal ke posisi kanan
        targetPosition = rightPosition;
        transform.position = rightPosition.position;
    }

    private void Update()
    {
        // Periksa input pemain (misalnya, tekan tombol A untuk kiri dan D untuk kanan)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Tentukan posisi target berdasarkan input pemain
        if (horizontalInput < 0)
        {
            targetPosition = leftPosition;
        }
        else if (horizontalInput > 0)
        {
            targetPosition = rightPosition;
        }

        // Pindahkan objek menuju posisi target
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
    }
}
