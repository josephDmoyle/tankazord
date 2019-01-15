using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private float power; 
    [SerializeField] private GameObject projectile;
    [SerializeField] Transform muzzle;
    public void Fire()
    {
        GameObject proj = Instantiate(projectile, muzzle.transform.position, muzzle.transform.rotation);
        proj.GetComponent<Rigidbody>().AddForce(muzzle.forward * power);
    }
}
