using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public ItemData data;
    public int level;
    public Waepon waepon;
    public Gear Gear;

    Image icon;
    Text textLevel;

    void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];
        icon.sprite = data.itemIcon;

        Text[] texts = GetComponentsInChildren<Text>();
        textLevel = texts[0];
    }

    

        private void LateUpdate()
    {
        textLevel.text = "Lv." + (level + 1);
    }

    public void OnClick()
    {
        switch (data.itemType)
        {
            case ItemData.ItemType.Melee:
            case ItemData.ItemType.Range:
                if (level == 0)
                {
                    GameObject newWaepon = new GameObject();
                    waepon = newWaepon.AddComponent<Waepon>();
                    waepon.Init(data);

                }
                else
                {
                    float nextDamage = data.baseDamage;
                    int nextCount = 0;

                    //대미지 공식은 계수, 관통력은 수치
                    nextDamage += data.baseDamage * data.damages[level];
                    nextCount += data.counts[level];

                    waepon.levelUp(nextDamage, nextCount);
                }
                level++;
                break;
            case ItemData.ItemType.Glove:
            case ItemData.ItemType.Shoe:
                if (level == 0)
                {
                    GameObject newGear = new GameObject();
                    Gear = newGear.AddComponent<Gear>();
                    Gear.Init(data);

                }
                else
                {
                    float nextRate = data.damages[level];
                    Gear.LevelUp(nextRate);
                }
                level++;
                break;
            case ItemData.ItemType.Heal:
                GameManager.instance.health = GameManager.instance.maxHealth;
                
                break;
        }

        


        if (level == data.damages.Length)
        {
            GetComponent<Button>().interactable = false;
        }
    }


}
