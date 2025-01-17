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

}
