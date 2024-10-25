using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTopD : MonoBehaviour
{
    Rigidbody rigid;
    public Collider pCollider;
    float moveSpeed = 5;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        pCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move(){
        float Horiz = Input.GetAxisRaw ("Horizontal");
        float vertical = Input.GetAxisRaw ("Vertical");

        rigid.velocity = new Vector3 (Horiz * moveSpeed, 0, vertical * moveSpeed);
    }

    public void activeTopD(){
        pCollider.enabled = true;
        this.enabled = true;
    }

    public void Change2D(){
        pCollider.enabled = false;
        rigid.velocity = Vector3.zero;
        this.enabled = false;
    }
}
