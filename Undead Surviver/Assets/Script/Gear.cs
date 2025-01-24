using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gear : MonoBehaviour
{
    
    public ItemData.ItemType type;

    public float rate;

    public void Init(ItemData data)
    {
        //기본 세팅
        name = "Gear" + data.itemId;
        transform.parent = GameManager.instance.player.transform;
        transform.localPosition = Vector3.zero;



        //프로퍼티 세팅
        type = data.itemType;
        rate = data.damages[0];
        ApplyGear();
    }

    public void LevelUp(float rate)
    {
        this.rate = rate;
        ApplyGear();
    }


    void ApplyGear()
    {
        switch(type) {
            case ItemData.ItemType.Glove:
                RateUp();
                break;
            case ItemData.ItemType.Shoe:
                SpeedUp();
                break;

        }
    }








    void RateUp()
    {
        Waepon[] waepons = transform.parent.GetComponentsInChildren<Waepon>();

        foreach(Waepon waepon in waepons)
        {
            switch (waepon.id)
            {
                case 0:
                    waepon.speed = 150 + (150 * rate); 
                    break;
                default:
                    waepon.speed = 0.5f * (1f - rate);
                    break;
            }
        }
    }

    void SpeedUp()
    {
        float speed = 3;
        GameManager.instance.player.speed = speed + speed * rate;
    }




}
