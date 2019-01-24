using UnityEngine;

namespace Princeps.Player
{
    public class PlaceHolderController : MonoBehaviour
    {

        public float moveSpeed = 10.0f;

        public Rigidbody rig { get; private set; }

        public Camera mainCamera { get; private set; }

        public Vector3 velocity { get; private set; }

        private void Awake()
        {
            this.rig = this.GetComponent<Rigidbody>( );
            this.mainCamera = Camera.main;
        }

        void Update()
        {
            // Get the mouse position on world coordinate
            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.y ) );
            this.transform.LookAt( mouseWorldPos + Vector3.up * transform.position.y );
            // Update the velocity for player
            this.velocity = new Vector3( Input.GetAxisRaw( "Horizontal" ), 0, Input.GetAxisRaw( "Vertical" ) ).normalized * this.moveSpeed;
        }

        private void FixedUpdate()
        {
            this.rig.MovePosition( this.rig.position + this.velocity * Time.fixedDeltaTime );
        }
    }
}
