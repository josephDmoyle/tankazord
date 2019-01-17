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
        }

        public void DrawField()
        {
            float x;
            float y;

            float angle = 20f;

            _uilr.Points = new Vector2[this.segments + 1];

            for ( int i = 0; i < ( this.segments + 1 ); i++ )
            {
                x = Mathf.Sin( Mathf.Deg2Rad * angle ) * this.viewRadius;
                y = Mathf.Cos( Mathf.Deg2Rad * angle ) * this.viewRadius;

                _uilr.Points[i] = new Vector2( x, y );

                angle += ( 360f / this.segments );
            }
        }
    }

}
