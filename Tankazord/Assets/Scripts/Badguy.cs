using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badguy : MonoBehaviour
{
    [SerializeField] float turnSensitivity, footSensitivity, cannonballSpeed = 0f;
    [SerializeField] private GameObject projectile;

    Transform target;
    Rigidbody body;
    Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        target = GameObject.FindObjectOfType<Controller>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 mov = target.position - transform.position;
        mov.y = 0f;

        transform.forward = mov;

        if(mov.magnitude < 40f)
            body.velocity = footSensitivity * new Vector3(mov.normalized.x, body.velocity.y, mov.normalized.z);
    }
}
