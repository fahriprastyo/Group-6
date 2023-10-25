using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerRak : MonoBehaviour
{
    public GameObject GantiRak;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GantiRak.SetActive(true);
        }
    }
     void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GantiRak.SetActive(false);
        }
    }
    
}
