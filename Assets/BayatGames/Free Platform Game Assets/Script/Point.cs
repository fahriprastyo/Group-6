using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
 public int Coin;
 

 public void GetCoin (int value){
    Coin += value;
    Debug.Log("Character has achieved a coin by 1:" + value.ToString());
 }

 
}
