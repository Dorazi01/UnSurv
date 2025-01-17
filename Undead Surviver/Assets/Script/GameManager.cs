using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //인스펙터의 속성을 이쁘게 구분시켜주는 헤더
    [Header("# Game Control")]

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

    /*다른 스크립트에서 GameManager.instance.원하는 함수나 변수에 접근이 가능함
      이와같은 기법을 싱글톤 패턴이라고 부른다.
    */

    public Player player;
    //게임 매니저에 해당하는 오브젝트가 들어가 있어야 함



    void Awake()
    {
        instance = this;
        //변수를 초기화 하는 작업이 필요함


    }
    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
        gameTime = maxGameTime;
        }



    }

    public void GetExp()
    {
        exp++;
        if (exp == nextExp[level])
        {
            level++;
            exp = 0;


        }
    }

}
