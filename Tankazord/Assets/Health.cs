using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float MaxHitPoints = 10;
    float HitPoints;
    Animator anim;

    private void Awake()
    {
        HitPoints = MaxHitPoints;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(HitPoints <= 0f)
        {
            anim.SetTrigger("Die");
        }
    }

    public void Damage(float dam)
    {
        HitPoints -= dam;
    }
}
