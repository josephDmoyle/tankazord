using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Player
{
    [SerializeField] float turnSensitivity, footSensitivity, cannonballSpeed = 0f;
    [SerializeField] Transform[] coordinates;
    [SerializeField] private GameObject projectile;
    [SerializeField] bool weaponsFree = false;

    float turn = 0f, rx = 0f, ry = 0f, lx = 0f, ly = 0f, go = 0f, prevFire = 0f;
    [SerializeField] float[] fire = new float[10];
    int coordinate = 0;
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
        rx = Input.GetAxis("RX");
        ry = Input.GetAxis("RY");
        lx = Input.GetAxis("LX");
        ly = Input.GetAxis("LY");

        for(int i = 0; i < 10; i++)
            fire[i] = Input.GetAxis("Fire" + i.ToString());

        if (rx > 0f && lx > 0f)
            turn = 1f;
        else if (rx < 0f && lx < 0f)
            turn = -1f;
        else
            turn = 0f;

        turn *= turnSensitivity * Time.fixedDeltaTime;

        transform.Rotate(0, turn, 0);

        anim.SetFloat("RLeg", ry);
        anim.SetFloat("LLeg", ly);

        Vector3 mov = transform.forward * go * footSensitivity;

        body.velocity = new Vector3(mov.x, body.velocity.y, mov.z);

        coordinate = 0;
        for (int i = 0; i < 10; i++)
            if (fire[i] > 0f)
                coordinate = i;

        if (coordinate > 0 && prevFire == 0f && go == 0f && turn == 0f && weaponsFree)
        {
            weaponsFree = false;
            anim.SetBool("Fire", true);
            Rigidbody proj = Instantiate(projectile, coordinates[coordinate].position + Vector3.up * 100, Quaternion.identity).GetComponent<Rigidbody>();
            proj.velocity = -Vector3.up * cannonballSpeed;
        }
        else
            anim.SetBool("Fire", false);

        prevFire = 0f;
        foreach (float f in fire)
            prevFire += f;
    }

    public void Walk(float speed)
    {
        go = speed;
    }
}
