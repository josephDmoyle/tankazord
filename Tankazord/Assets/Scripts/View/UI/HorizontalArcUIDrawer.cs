using UnityEngine;
using UnityEngine.UI.Extensions;

namespace Princeps.Player.UI
{
    [RequireComponent( typeof( UICircle ) )]
    public class HorizontalArcUIDrawer : MonoBehaviour
    {
        [Range( 0, 50 )]
        public int segments = 50;

        private UILineRenderer _uilr;

        private void Awake()
        {
            _uilr = this.GetComponent<UILineRenderer>( );
            _uilr.Points = new Vector2[this.segments + 1];
        }

        public void DrawArc( float arcAngle, float radius )
        {
            float x;
            float y;
            float angle = -arcAngle / 2;

            for ( int i = 0; i < ( this.segments + 1 ); i++ )
            {
                x = Mathf.Sin( Mathf.Deg2Rad * angle ) * radius;
                y = Mathf.Cos( Mathf.Deg2Rad * angle ) * radius;

                _uilr.Points[i] = new Vector2( x, y );

                angle += ( arcAngle / this.segments );
            }
        }
    }
}