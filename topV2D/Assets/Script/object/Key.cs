using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject[] keyObject;
    void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == 7){
            for (int i = 0; i< keyObject.Length; i++){
                if(keyObject[i] != null){
                    Destroy(keyObject[i]);
                }
            }
            Destroy(gameObject);
        }
    }
}
