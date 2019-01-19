using UnityEngine;
using UnityEngine.UI.Extensions;

namespace Princeps.Player.UI
{
    [RequireComponent( typeof( UILineRenderer ) )]
    public class ViewBoundaryUIDrawer : MonoBehaviour
    {
        [Range( 0, 50 )]
        public int segments = 50;

        private UILineRenderer _uilr;

        private void Awake()
        {
            _uilr = this.GetComponent<UILineRenderer>( );
            _uilr.Points = new Vector2[2];
        }

        private void Start()
        {

        }

        public void DrawBoundary( float radius, Vector2 direction )
        {
            var startPosition = Vector2.zero;
            _uilr.Points[0] = startPosition;
            _uilr.Points[1] = startPosition + radius * direction;
        }
    }
}

