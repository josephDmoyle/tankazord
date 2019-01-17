using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Player
{
    [SerializeField] Transform hull, footL, footR;
    [SerializeField] float turnSensitivity, footSensitivity;
    [SerializeField] Cannon cannon;

    float turn = 0f, rx = 0f, ry = 0f, lx = 0f, ly = 0f, go = 0f, fire = 0f, prevFire = 0f;

    Rigidbody body;
    Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        turn = Input.GetAxis("Turn") * turnSensitivity;
        rx = Input.GetAxis("RX");
        ry = Input.GetAxis("RY");
        lx = Input.GetAxis("LX");
        ly = Input.GetAxis("LY");
        fire = Input.GetAxis("Fire");

        turn *= Time.fixedDeltaTime;

        transform.Rotate(0, turn, 0);

        anim.SetFloat("RLeg", ry);
        anim.SetFloat("LLeg", ly);

        Vector3 mov = transform.forward * go * footSensitivity;

        body.velocity = new Vector3(mov.x, body.velocity.y, mov.z);

        if (fire > 0f && prevFire == 0f && go == 0f && turn == 0f)
        {
            anim.SetTrigger("Fire");
        }
        prevFire = fire;

    }

    public void Walk(float speed)
    {
        go = speed;
    }

    public void Fire()
    {
        cannon.Fire();
    }
}
