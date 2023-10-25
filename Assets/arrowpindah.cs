using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderOnClick : MonoBehaviour
{
    public int sceneIndex; // Index scene yang akan dimuat

    // Fungsi ini akan dipanggil saat GameObject diklik
    private void OnMouseDown()
    {
        // Melakukan perpindahan scene
        SceneManager.LoadScene(sceneIndex);
    }
}
