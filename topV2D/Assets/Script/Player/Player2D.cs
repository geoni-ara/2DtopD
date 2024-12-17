using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player2D : MonoBehaviour
{
    Rigidbody rigid;
    Collider pCollider;
    int jumpCount = 0;
    float moveSpeed = 5;
    public Transform[] spawnPoint;
    void Awake(){
        rigid = GetComponent<Rigidbody> ();
        pCollider = GetComponent<BoxCollider> ();
        active2D();
    }
    void Update()
    {
        Move();
        jump();
        //rigid.AddForce(new Vector3(0,0,-9.8f), ForceMode.Acceleration);
    }

    void FixedUpdate(){
        rigid.AddForce(new Vector3(0,0,-9.8f), ForceMode.Acceleration);
    }
    
    void Move(){
        float Horiz = Input.GetAxisRaw ("Horizontal");
        
        rigid.velocity = new Vector3(Horiz * moveSpeed, 0, rigid.velocity.z);
        if(Horiz > 0){
            transform.rotation = Quaternion.Euler(0, 90, 90);
        }else if(Horiz < 0){
            transform.rotation = Quaternion.Euler(0, -90, -90);
        }
    }

    void jump(){
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2){
            rigid.AddForce (0, 0, 7, ForceMode.Impulse);
            jumpCount++;   
        }
    }

    public void active2D(){
        pCollider.enabled = true;
        this.enabled = true;
    }

    public void ChangeTopD(){
        //Physics.gravity = Vector3.zero;
        pCollider.enabled = false;
        rigid.velocity = Vector3.zero;
        this.enabled = false;
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Platform")){
            jumpCount = 0;
        }
    }

    public void moveSpawn(int index){
        transform.position = spawnPoint[index].position;
    }
}
