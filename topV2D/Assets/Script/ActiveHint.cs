using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveHint : MonoBehaviour
{
    public GameObject target;

    public void ToggleUI()
    {
        if (target != null)
        {
            bool isActive = target.activeSelf; // 현재 활성화 상태 가져오기
            target.SetActive(!isActive);       // 상태를 반전시킴 (켜져있으면 끄고, 꺼져있으면 켬)
        }
    }
    
}
