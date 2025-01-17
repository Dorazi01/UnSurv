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
        //���� ��ǥ�� ȭ�� ��ǥ��� �ٸ�
        rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);//���� ���� ������Ʈ ��ġ�� ��ũ�� ��ǥ�� ��ȯ
    }
}
