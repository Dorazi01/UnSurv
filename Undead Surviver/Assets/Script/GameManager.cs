using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //�ν������� �Ӽ��� �̻ڰ� ���н����ִ� ���
    [Header("# Game Control")]
    public bool isLive;
    public float gameTime;
    public float maxGameTime = 2 * 10f;

    [Header("# Player Info")]
    public int playerId;
    public int level;
    public float health;
    public float maxHealth = 100;
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
    public Result uiResult;
    public GameObject enemyCleaner;

    void Awake()
    {
        instance = this;
        //������ �ʱ�ȭ �ϴ� �۾��� �ʿ���


    }

    public void GameStart(int id)
    {
        playerId = id;
        health = maxHealth;

        player.gameObject.SetActive(true);
        uiLevelUp.Select(playerId % 2);
        Resume();


        AudioManager.instance.PlayBgm(true);

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);


    }



    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }


    IEnumerator GameOverRoutine()
    {
        isLive = false;

        yield return new WaitForSeconds(0.5f);

        uiResult.gameObject.SetActive(true);
        uiResult.Lose();

        Stop();

        AudioManager.instance.PlayBgm(false);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Lose);

    }

    public void GameVictory()
    {
        StartCoroutine(GameVictoryRoutine());
    }


    IEnumerator GameVictoryRoutine()
    {
        isLive = false;
        enemyCleaner.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        uiResult.gameObject.SetActive(true);
        uiResult.Win();
        Stop();

        AudioManager.instance.PlayBgm(false);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Win);

    }





    public void GameRetry()
    {
        SceneManager.LoadScene("Undead");
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);

    }




    void Update()
    {
        if (!isLive)
            return;

        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
        gameTime = maxGameTime;
        GameVictory();
        }



    }

    public void GetExp()
    {
        if (!isLive) return;
        
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
