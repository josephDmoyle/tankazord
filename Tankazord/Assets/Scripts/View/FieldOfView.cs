using Princeps.Enemy;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Princeps.Player
{
    public class FieldOfView : MonoBehaviour
    {
        public float viewUpdateCoolDownTime = 0.2f;

        public float viewRadius;

        [Range( 0, 180 )]
        public float viewAngle;

        public LayerMask targetMask;

        private float _timer;

        private List<Collider> _cachedCollidersInView;

        private List<Collider> _collidersInView;

        public Vector3 DirectionFromAngle( float angle, bool isGlobalAngle = true )
        {
            if ( !isGlobalAngle )
            {
                angle += this.transform.eulerAngles.y;
            }
            return new Vector3( Mathf.Sin( angle * Mathf.Deg2Rad ), 0, Mathf.Cos( angle * Mathf.Deg2Rad ) );
        }

        private void FindVisableTargets()
        {
            _collidersInView.Clear( );
            var collidersInSphere = Physics.OverlapSphere( this.transform.position, this.viewRadius, this.targetMask );
            for ( int i = 0; i < collidersInSphere.Length; i++ )
            {
                var targetTransform = collidersInSphere[i].transform;
                var direction = ( targetTransform.transform.position - this.transform.position ).normalized;
                if ( Vector3.Angle( this.transform.forward, direction ) < viewAngle / 2 )
                {
                    // Assuming there are no obstacles
                    var target = targetTransform.GetComponent<Target>( );
                    target.inSight = true;
                    _collidersInView.Add( collidersInSphere[i] );
                }
            }
            // Use the an array pointer to record the colliders which can be viewed last frame.
            if ( _cachedCollidersInView != null )
            {
                for ( int i = 0; i < _cachedCollidersInView.Count; i++ )
                {
                    var previousCollider = _cachedCollidersInView[i];
                    if ( !_collidersInView.Contains( previousCollider ) )
                    {
                        previousCollider.GetComponent<Target>( ).inSight = false;
                    }
                }
            }
            _cachedCollidersInView.Clear( );
            _cachedCollidersInView.AddRange( _collidersInView );
        }

        private void Awake()
        {
            _timer = 0.0f;
        }

        private void Start()
        {
            _collidersInView = new List<Collider>( );
            _cachedCollidersInView = new List<Collider>( );
        }

        private void Update()
        {
            // Use the timer to update the view based on a constant time.
            _timer += Time.deltaTime;
            if ( _timer > this.viewUpdateCoolDownTime )
            {
                _timer = 0.0f;
                //Update view now
                this.FindVisableTargets( );
            }
        }
    }
}
