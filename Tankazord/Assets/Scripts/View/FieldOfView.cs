using Princeps.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace Princeps.Player
{
    public class FieldOfView : MonoBehaviour
    {
        public float viewUpdateCoolDownTime = 0.2f;

        public float viewRadius;

        public CircleViewDrawer circleDrawer;

        public ViewBoundaryDrawer boundaryDrawer_1;

        public ViewBoundaryDrawer boundaryDrawer_2;

        public ViewUIController uiController;

        [Range( 0, 180 )]
        public float viewAngle;

        public LayerMask targetMask;

        private float _timer;

        private List<Collider> _cachedCollidersInView;

        private List<Collider> _collidersInView;

        private LineRenderer _lineRenderer;

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
            this.uiController.CleanTargets( );
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

                    // Draw the target on the view ui
                    // The percentage for radius
                    float radiusPercentage = Vector3.Magnitude( target.transform.position - this.transform.position ) / this.viewRadius;
                    // Rotate the dircetion vector transform.eulerAngles.y counterclockwise
                    float sin = Mathf.Sin( this.transform.eulerAngles.y * Mathf.Deg2Rad );
                    float cos = Mathf.Cos( this.transform.eulerAngles.y * Mathf.Deg2Rad );
                    Vector2 normalizeDir = new Vector2( direction.x * cos - direction.y * sin, direction.x * sin + direction.y * cos );
                    this.uiController.DrawTarget( normalizeDir, radiusPercentage );
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
            _lineRenderer = this.GetComponent<LineRenderer>( );
        }

        private void Start()
        {
            _collidersInView = new List<Collider>( );
            _cachedCollidersInView = new List<Collider>( );
            // Draw the view field
            this.circleDrawer.DrawCircle( this.viewRadius );
            var viewDir_1 = this.DirectionFromAngle( -this.viewAngle / 2, false );
            var viewDir_2 = this.DirectionFromAngle( this.viewAngle / 2, false );
            this.uiController.Setup( new Vector2( viewDir_1.x, viewDir_1.z ), new Vector2( viewDir_2.x, viewDir_2.z ) );
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

            // Update the actual view boundary in scene
            var viewDir_1 = this.DirectionFromAngle( -this.viewAngle / 2, false );
            var viewDir_2 = this.DirectionFromAngle( this.viewAngle / 2, false );
            this.boundaryDrawer_1.DrawBoundary( this.transform.position, this.transform.position + viewDir_1 * this.viewRadius );
            this.boundaryDrawer_2.DrawBoundary( this.transform.position, this.transform.position + viewDir_2 * this.viewRadius );
        }
    }
}
