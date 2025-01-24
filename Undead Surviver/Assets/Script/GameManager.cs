using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //�ν������� �Ӽ��� �̻ڰ� ���н����ִ� ���
    [Header("# Game Control")]
    public bool isLive;
    public float gameTime;
    public float maxGameTime = 2 * 10f;

    [Header("# Player Info")]
    public int level;
    public int health;
    public int maxHealth = 100;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };



    [Header("# Game Object")]
    public PoolManager pool;

    /*�ٸ� ��ũ��Ʈ���� GameManager.instance.���ϴ� �Լ��� ������ ������ ������
      �̿Ͱ��� ����� �̱��� �����̶�� �θ���.
    */

    public Player player;
    //���� �Ŵ����� �ش��ϴ� ������Ʈ�� �� �־�� ��

    public LevelUp uiLevelUp;



    void Awake()
    {
        instance = this;
        //������ �ʱ�ȭ �ϴ� �۾��� �ʿ���


    }

    private void Start()
    {
        health = maxHealth;

        //�ӽ� (ĳ���� ����)
        uiLevelUp.Select(0);

    }
    void Update()
    {
        if (!isLive)
            return;

        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
        gameTime = maxGameTime;
        }



    }

    public void GetExp()
    {
        exp++;
        if (exp == nextExp[Mathf.Min(level, nextExp.Length-1)])
        {
            level++;
            exp = 0;
            uiLevelUp.Show();

        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive= true;
        Time.timeScale = 1;
    }

}
