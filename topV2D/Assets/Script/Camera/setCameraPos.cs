using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setCameraPos : MonoBehaviour
{

    public Vector3 CameraOffset;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CameraOffset+ player.transform.position;
    }
}
