using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
  void OnTriggerEnter2D (Collider2D other) {
        if(other.transform.CompareTag("Player")) {
            Point point = other.GetComponent<Point>();
            point.GetCoin(1);
            Destroy(this.gameObject);
        }
  }
}
