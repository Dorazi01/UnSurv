using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameMananger : MonoBehaviour
{
    public static GameMananger instance;
    /*�ٸ� ��ũ��Ʈ���� GameManager.instance.���ϴ� �Լ��� ������ ������ ������
      �̿Ͱ��� ����� �̱��� �����̶�� �θ���.
    */

    public Player player;
    //���� �Ŵ����� �ش��ϴ� ������Ʈ�� �� �־�� ��

    void Awake()
    {
        instance = this;
        //������ �ʱ�ȭ �ϴ� �۾��� �ʿ���


    }

}
