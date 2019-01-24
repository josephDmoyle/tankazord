using UnityEngine;

public class Badguy : MonoBehaviour
{
    [SerializeField] float turnSensitivity, footSensitivity, cannonballSpeed = 0f, attackTime = 5f, timer = 0f;

    Transform target;
    Rigidbody body;
    Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody>( );
        anim = GetComponent<Animator>( );
        target = GameObject.FindObjectOfType<Controller>( ).transform;
    }

    private void FixedUpdate()
    {
        Vector3 mov = target.position - transform.position;
        mov.y = 0f;
        transform.rotation = Quaternion.RotateTowards( transform.rotation, Quaternion.LookRotation( mov ), turnSensitivity );
        if ( Vector3.Distance( transform.position, target.position ) > 50f )
            body.velocity = footSensitivity * new Vector3( mov.normalized.x, body.velocity.y, mov.normalized.z );
    }
}
