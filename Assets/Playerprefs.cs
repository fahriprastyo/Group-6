using UnityEngine;

public class SavePlayerPositionInHome : MonoBehaviour
{
    public Transform playerTransform; // Referensi ke transform pemain

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Simpan posisi pemain dalam PlayerPrefs
            PlayerPrefs.SetFloat("PlayerPosX", playerTransform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", playerTransform.position.y);
        }
    }
}
