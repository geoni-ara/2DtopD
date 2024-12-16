using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Player")){
            Invoke("Del",1);
        }
    }

    void Del(){
        Destroy(gameObject);
    }
}
