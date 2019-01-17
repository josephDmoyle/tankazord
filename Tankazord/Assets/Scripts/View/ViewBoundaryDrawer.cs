using UnityEngine;

namespace Princeps.Player
{
    [RequireComponent( typeof( LineRenderer ) )]
    public class ViewBoundaryDrawer : MonoBehaviour
    {
        [Range( 0, 30 )]
        public int segments = 20;

        private LineRenderer _lineRenderer;


        private void Awake()
        {
            _lineRenderer = this.GetComponent<LineRenderer>( );
        }

        public void DrawBoundary( Vector3 startPosition, Vector3 endPosition )
        {
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition( 0, startPosition );
            _lineRenderer.SetPosition( 1, endPosition );
        }
    }
}
