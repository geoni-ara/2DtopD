    using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Timeline;

public class InteractiveObject : MonoBehaviour
{

    public GameObject AttachObject;
    public Transform AttachPoint;
    public GameObject TopDCamera;
    bool isHolding = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && TopDCamera.activeSelf){
            if(isHolding){
                DropObject();
            }else{
                CheckObject();
                if(AttachObject != null){
                    PickUpObject();
                }
            }
        }
        if(AttachObject != null){
            setPos();
        }
    }

    void CheckObject(){
        float radius = 0.9f;
        Vector3 position = transform.position;

        Collider[] hitColliders = Physics.OverlapSphere(position, radius);

        AttachObject = null;

        foreach(Collider hitCollider in hitColliders){
            if(hitCollider.gameObject.layer == 6){
                AttachObject = hitCollider.gameObject;
                break;
            }
        }
    }

    void PickUpObject(){
        if(AttachObject != null){
            AttachObject.transform.position = AttachPoint.position;
            AttachObject.transform.rotation = AttachPoint.rotation;
            Collider itemCollider = AttachObject.GetComponent<Collider>();
            itemCollider.enabled = false;

            AttachObject.transform.SetParent(AttachPoint);
            isHolding = true;

        }
    }

    void DropObject(){
        if(AttachObject != null){
            AttachObject.transform.SetParent(null);
            Vector3 dropPosition = AttachPoint.position;
            dropPosition.y = 0;
            AttachObject.transform.position=dropPosition;

            Collider itemCollider = AttachObject.GetComponent<Collider>();
            itemCollider.enabled = true;

            AttachObject = null;
            isHolding = false;
        }
    }

    void setPos(){
        AttachObject.transform.position = AttachPoint.position;
    }
}
