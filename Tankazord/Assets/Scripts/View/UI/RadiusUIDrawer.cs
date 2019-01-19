using UnityEngine;
using UnityEngine.UI.Extensions;

namespace Princeps.Player.UI
{
    [RequireComponent( typeof( UILineRenderer ) )]
    public class RadiusUIDrawer : MonoBehaviour
    {
        private UILineRenderer _uilr;

        private void Awake()
        {
            _uilr = this.GetComponent<UILineRenderer>( );
            _uilr.Points = new Vector2[2];
        }

        public void DrawRadius( float angle, float radius )
        {
            var dir = new Vector2( Mathf.Sin( angle * Mathf.Deg2Rad ), Mathf.Cos( angle * Mathf.Deg2Rad ) ).normalized;
            _uilr.Points[1] = dir * radius;
        }
    }
}
