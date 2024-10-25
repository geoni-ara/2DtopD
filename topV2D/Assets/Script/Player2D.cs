using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    Rigidbody rigid;
    Collider pCollider;
    float moveSpeed = 8;
    void Awake(){
        rigid = GetComponent<Rigidbody> ();
        pCollider = GetComponent<BoxCollider> ();
        active2D();
    }
    void Update()
    {
        Move();
        jump();
    }
    
    void Move(){
        float Horiz = Input.GetAxisRaw ("Horizontal");
        rigid.velocity = new Vector3(Horiz * moveSpeed, rigid.velocity.y, rigid.velocity.z);
    }

    void jump(){
        if(Input.GetKeyDown(KeyCode.Space)){
            rigid.AddForce (0, 0, 5, ForceMode.Impulse);   
        }
    }

    public void active2D(){
        Physics.gravity = new Vector3(0, 0, -9.81f);
        pCollider.enabled = true;
        this.enabled = true;
    }

    public void ChangeTopD(){
        Physics.gravity = Vector3.zero;
        pCollider.enabled = false;
        rigid.velocity = Vector3.zero;
        this.enabled = false;
    }
}
