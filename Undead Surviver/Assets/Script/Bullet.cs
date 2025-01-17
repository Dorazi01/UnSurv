using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //대미지와 관통력 설정
    public float damage;
    public int per;

    public void Init(float damage, int per)
    {
        this.damage = damage;
        this.per = per;
    }




}
