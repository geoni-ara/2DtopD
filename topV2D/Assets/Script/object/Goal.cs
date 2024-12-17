using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject Portal;
    public GameObject[] mapItem;
    bool GoalInPlayer1 = false;
    bool GoalInPlayer2 = false; 
    bool isClear=false;
    

    void OnTriggerStay(Collider other){
        if(other.gameObject.layer == 7 && !isClear){
            Portal.SetActive(true);
            Player2D player1 = other.GetComponent<Player2D>();
            PlayerTopD player2 = other.GetComponent<PlayerTopD>();

            if(GoalInPlayer1 && GoalInPlayer2){
                isClear = true;
                Clear();
            }
            if(player1 != null){
                GoalInPlayer1 = true;
            }
            if(player2 != null){
                GoalInPlayer2 = true;
            }
        }
    }

    void Clear(){
        for(int i = 0; i < mapItem.Length; i++){
            if(mapItem[i] != null){
                Destroy(mapItem[i]);
            }
        }
        GameManager.info.mapIndex ++;
        GameManager.info.activeNextMap(GameManager.info.mapIndex);
    }
}
