using UnityEngine;

namespace Princeps.Player
{
    [RequireComponent( typeof( LineRenderer ) )]
    public class CircleViewDrawer : MonoBehaviour
    {
        [Range( 0, 50 )]
        public int segments = 50;

        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = this.GetComponent<LineRenderer>( );
        }

        public void DrawCircle( float viewRadius )
        {
            float x;
            float z;

            float angle = 20f;

            _lineRenderer.positionCount = segments + 1;
            _lineRenderer.useWorldSpace = false;

            for ( int i = 0; i < ( this.segments + 1 ); i++ )
            {
                x = Mathf.Sin( Mathf.Deg2Rad * angle ) * viewRadius;
                z = Mathf.Cos( Mathf.Deg2Rad * angle ) * viewRadius;

                _lineRenderer.SetPosition( i, new Vector3( x, 0, z ) );

                angle += ( 360f / this.segments );
            }
        }
    }
}
