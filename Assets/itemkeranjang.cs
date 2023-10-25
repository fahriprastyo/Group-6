using UnityEngine;

public class itemkeranjang: MonoBehaviour
{
    public int Indomie = 0; // Variabel untuk menyimpan skor "Indomie"

    // Metode untuk menambah skor Indomie
    public void GetIndomie(int value)
    {
        Indomie += value;
        Debug.Log("Beli Mie satu " + value.ToString());
    }

    // Metode lain dan kode pemain lainnya
}
