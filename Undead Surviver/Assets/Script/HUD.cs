using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Exp, Level, Kill, Time, Health }
    public InfoType type;

    Text myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                //스랄이더에 적용할 값 : 현재경험치 / 최대 경험치
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[GameManager.instance.level];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:                                                                //F0의 경우 소숫점 X
                myText.text = string.Format("LV. {0:F0}", GameManager.instance.level);          //Format("문자열  {0:F0}"
                break;
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManager.instance.kill);
                break;
            case InfoType.Time:
                float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}",min,sec);                           //D0는 자릿수 지정
                break;
            case InfoType.Health:
                float curHealth = GameManager.instance.exp;
                float maxHealth = GameManager.instance.nextExp[GameManager.instance.level];
                mySlider.value = curHealth / maxHealth;
                break;

            default:
                break;
        }
    }
}
