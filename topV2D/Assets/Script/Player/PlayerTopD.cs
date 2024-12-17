using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerTopD : MonoBehaviour
{
    Rigidbody rigid;
    Collider pCollider;
    public Transform[] spawnPoint;

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

        Vector3 moveDirection = new Vector3(Horiz, 0, vertical);
        rigid.velocity = moveDirection * moveSpeed;
        if(moveDirection != Vector3.zero){
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
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

    public void moveSpawn(int index){
        transform.position = spawnPoint[index].position;
    }
}
