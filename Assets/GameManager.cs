using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    // ... (Kode lainnya)

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
