using UnityEngine;

public class InitializePlayerPositionInJalan : MonoBehaviour
{
    public Transform playerTransform; // Referensi ke transform pemain

    private void Start()
    {
        // Ambil posisi pemain dari PlayerPrefs
        float playerPosX = PlayerPrefs.GetFloat("PlayerPosX", 0f);
        float playerPosY = PlayerPrefs.GetFloat("PlayerPosY", 0f);

        // Posisikan pemain ke posisi yang diambil dari PlayerPrefs
        playerTransform.position = new Vector2(playerPosX, playerPosY);
    }
}
