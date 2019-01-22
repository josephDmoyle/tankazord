using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float MaxHitPoints = 10;
    [SerializeField] GameObject explosion;

    float HitPoints;

    private void Awake()
    {
        HitPoints = MaxHitPoints;
    }

    void FixedUpdate()
    {
        if(HitPoints <= 0f)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void Damage(float dam)
    {
        HitPoints -= dam;
    }
}
