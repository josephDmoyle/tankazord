using UnityEditor;
using UnityEngine;

namespace Princeps.Player
{
    [CustomEditor( typeof( FieldOfView ) )]
    public class FieldOfViewEditor : Editor
    {
        public FieldOfView view { get; private set; }

        private void OnEnable()
        {
            if ( view == null )
            {
                view = (FieldOfView)this.target;
            }
        }

        private void OnSceneGUI()
        {
            var cachedColor = Handles.color;
            Handles.color = Color.white;
            Handles.DrawWireArc( view.transform.position, Vector3.up, Vector3.forward, 360, view.viewRadius );
            Handles.color = Color.cyan;
            var viewDir_1 = view.DirectionFromAngle( -view.viewAngle / 2, false );
            var viewDir_2 = view.DirectionFromAngle( view.viewAngle / 2, false );

            // Draw the vision on the scene window
            Handles.DrawLine( view.transform.position, view.transform.position + viewDir_1 * view.viewRadius );
            Handles.DrawLine( view.transform.position, view.transform.position + viewDir_2 * view.viewRadius );

            Handles.color = cachedColor;
        }
    }
}