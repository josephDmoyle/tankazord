using UnityEngine;
using UnityEngine.UI.Extensions;

namespace Princeps.Player
{
    [RequireComponent( typeof( UILineRenderer ) )]
    public class FieldOfViewUIDrawer : MonoBehaviour
    {
        [Range( 0, 50 )]
        public int segments = 50;

        public float viewRadius = 50.0f;

        private UILineRenderer _uilr;

        private void Awake()
        {
            _uilr = this.GetComponent<UILineRenderer>( );
            _uilr.Points = new Vector2[this.segments + 1];
        }

        private void Start()
        {

        }

        public void DrawField( float arcAngle )
        {
            float x;
            float y;
            float angle = -arcAngle / 2;

            for ( int i = 0; i < ( this.segments + 1 ); i++ )
            {
                x = Mathf.Sin( Mathf.Deg2Rad * angle ) * this.viewRadius;
                y = Mathf.Cos( Mathf.Deg2Rad * angle ) * this.viewRadius;

                _uilr.Points[i] = new Vector2( x, y );

                angle += ( arcAngle / this.segments );
            }
        }
    }

}
