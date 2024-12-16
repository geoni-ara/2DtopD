using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class obstable : MonoBehaviour
{
    void OnCollisionStay(Collision collision){
        Debug.Log(collision);
        if(collision.gameObject.layer == 6){ // 레이어가 박스라면

            Debug.Log("11");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }    
}
