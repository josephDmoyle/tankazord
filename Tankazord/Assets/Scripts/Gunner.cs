using UnityEngine;

public class Gunner : Player
{
    [SerializeField]Cannon cannon;
    float fire = 0f, prevFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        fire = Input.GetAxis("Fire");
        if(fire > 0f && prevFire == 0f)
        {
            cannon.Fire();
        }
        prevFire = fire;
    }
}
