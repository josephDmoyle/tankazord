using System.Collections.Generic;
using UnityEngine;

namespace Princeps.Player
{
    public class Captain : MonoBehaviour
    {
        public Missile missilePrefab;

        public FieldOfView view;

        public TargetManager targetManager;

        public float missileCoolDown = 1.0f;

        private List<KeyCode> _keycodes;

        private float _missileTimer;

        private void Awake()
        {
        }

        // Start is called before the first frame update
        void Start()
        {
            this.SetupKeycodes( );
        }

        // Update is called once per frame
        void Update()
        {
            _missileTimer += Time.deltaTime;
            if ( _missileTimer >= this.missileCoolDown )
            {
                this.FireMissile( );
            }
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
                            _missileTimer = 0.0f;
                            Instantiate<Missile>( this.missilePrefab, new Vector3( target.transform.position.x, this.transform.position.y + this.missilePrefab.instantiateHeight, target.transform.position.z ), Quaternion.identity, null );
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