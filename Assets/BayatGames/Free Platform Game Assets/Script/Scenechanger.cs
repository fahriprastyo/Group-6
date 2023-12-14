using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class LevelMove_Ref : MonoBehaviour
{
    public int sceneBuildIndex;
    private bool playerInside = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            playerInside = true;
            print("Player entered trigger zone.");
            Invoke("LoadNextScene", 3f); // Pindah scene setelah 3 detik
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            playerInside = false;
            print("Player exited trigger zone.");
            CancelInvoke("LoadNextScene"); // Batalkan pemanggilan jika pemain keluar sebelum 3 detik
        }
    }

    private void LoadNextScene() {
        if(playerInside) {
            print("Switching Scene to " + sceneBuildIndex);

            // Simpan posisi pemain sebelum beralih scene
            PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);

            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
