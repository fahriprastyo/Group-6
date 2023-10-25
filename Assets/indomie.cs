using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public Transform playerTransform; // Anda bisa menetapkan transform pemain melalui Inspector
    //public PlayerScore playerScore;
   //private bool isTriggerActive = false; // Menandakan apakah is trigger aktif
    public GameObject spawnedObjectPrefab;

    private void Start()
    {
        
    }

    private void Update()
    {
        
        }
    



    private void OnTriggerEnter2D(Collider2D other)
    {
        // Periksa apakah objek yang menyentuh adalah pemain
        if (other.CompareTag("keranjang"))
        {
            // Panggil metode yang akan menghilangkan objek makanan
            DestroyFood();
        }
    }

    private void DestroyFood()
    {
        // Hancurkan objek makanan
        Destroy(gameObject);
    }
}