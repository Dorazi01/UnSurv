using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    RectTransform rect;



    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }



    private void FixedUpdate()
    {
        //월드 좌표와 화면 좌표계는 다름
        rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);//월드 상의 오브젝트 위치를 스크린 좌표로 변환
    }
}
