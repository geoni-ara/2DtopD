using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager info {get {return instance;}}
    private static GameManager instance;
    public GameObject Camera2D;
    public GameObject CameraTopD;
    public GameObject player2D;
    public GameObject playerTopD;

    void  Awake(){
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this);
        ChangeCamera();
    }

    public void ChangeCamera(){
        if(Camera2D.activeSelf){
            Camera2D.SetActive(false);
            CameraTopD.SetActive(true);
            player2D.GetComponent<Player2D>().ChangeTopD();
            playerTopD.GetComponent<PlayerTopD>().activeTopD();

            Camera2D.tag = "Untagged";
            CameraTopD.tag = "MainCamera";
        }else if (CameraTopD.activeSelf){
            Camera2D.SetActive(true);
            CameraTopD.SetActive(false);
            player2D.GetComponent<Player2D>().active2D();
            playerTopD.GetComponent<PlayerTopD>().Change2D();

            Camera2D.tag = "MainCamera";
            CameraTopD.tag = "Untagged";
        }
    }
}
