using System.Collections.Generic;
using UnityEngine;

namespace Princeps.Player
{
    public class Captain : MonoBehaviour
    {
        public float moveSpeed = 10.0f;

        public Rigidbody rigidbody { get; private set; }

        public Camera mainCamera { get; private set; }

        public Vector3 velocity { get; private set; }

        public Missile missilePrefab;

        public FieldOfView view;

        public TargetManager targetManager;

        private List<KeyCode> _keycodes;

        private void Awake()
        {
            this.rigidbody = this.GetComponent<Rigidbody>( );
            this.mainCamera = Camera.main;
        }

        // Start is called before the first frame update
        void Start()
        {
            this.SetupKeycodes( );
        }

        // Update is called once per frame
        void Update()
        {
            // Get the mouse position on world coordinate
            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.y ) );
            this.transform.LookAt( mouseWorldPos + Vector3.up * transform.position.y );
            // Update the velocity for player
            this.velocity = new Vector3( Input.GetAxisRaw( "Horizontal" ), 0, Input.GetAxisRaw( "Vertical" ) ).normalized * this.moveSpeed;
            // Fire the Missile
            this.FireMissile( );
        }

        private void FixedUpdate()
        {
            this.rigidbody.MovePosition( this.rigidbody.position + this.velocity * Time.fixedDeltaTime );
        }


        private void FireMissile()
        {
            // Hardcode the keycode first;
            if ( Input.anyKeyDown )
            {
                foreach ( var key in _keycodes )
                {
                    if ( Input.GetKeyDown( key ) )
                    {
                        var targetName = "Target_" + key.ToString( ).Substring( 5 );
                        var target = targetManager.targetPoints.Find( t => t.name == targetName );
                        if ( target != null )
                        {
                            Instantiate<Missile>( this.missilePrefab, new Vector3( target.transform.position.x, this.transform.position.y + this.missilePrefab.instantiateHeight, target.transform.position.z), Quaternion.identity, null );
                        }
                        break;
                    }
                }

            }
        }

        private void SetupKeycodes()
        {
            _keycodes = new List<KeyCode>( );
            _keycodes.Add( KeyCode.Alpha1 );
            _keycodes.Add( KeyCode.Alpha2 );
            _keycodes.Add( KeyCode.Alpha3 );
            _keycodes.Add( KeyCode.Alpha4 );
            _keycodes.Add( KeyCode.Alpha5 );
            _keycodes.Add( KeyCode.Alpha6 );
            _keycodes.Add( KeyCode.Alpha7 );
            _keycodes.Add( KeyCode.Alpha8 );
            _keycodes.Add( KeyCode.Alpha9 );
        }
    }
}
