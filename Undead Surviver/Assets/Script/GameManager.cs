using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float gameTime;
    public float maxGameTime = 2 * 10f;

    public PoolManager pool;
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
    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
        gameTime = maxGameTime;
        }



    }

}
