using UnityEngine;

public class KardusIndomie : MonoBehaviour
{
    public GameObject keranjang; // Ganti dengan GameObject keranjang yang ingin Anda gunakan
    public GameObject miePrefab;
    public float flyingSpeed = 10f;

    private void OnMouseDown()
    {
        if (keranjang != null && miePrefab != null)
        {
            Vector2 direction = (keranjang.transform.position - transform.position).normalized;

            GameObject mie = Instantiate(miePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb2D = mie.GetComponent<Rigidbody2D>();
            rb2D.velocity = direction * flyingSpeed;

            // Tambah skor "Indomie" pemain dengan nilai 1
            keranjang.GetComponent<itemkeranjang>().GetIndomie(1);
        }
        else
        {
            Debug.LogError("Keranjang or mie prefab is not assigned!");
        }
    }
}
