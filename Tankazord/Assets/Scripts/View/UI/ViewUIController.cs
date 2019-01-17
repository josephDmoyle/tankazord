using UnityEngine;

namespace Princeps.Player
{
    public class ViewUIController : MonoBehaviour
    {
        public FieldOfViewUIDrawer fieldDrawer;

        public ViewBoundaryUIDrawer boundaryDrawer_1;

        public ViewBoundaryUIDrawer boundaryDrawer_2;

        public void Setup( Vector2 boundaryDir_1, Vector2 boundaryDir_2 )
        {
            this.fieldDrawer.DrawField( );
            this.boundaryDrawer_1.DrawBoundary( this.fieldDrawer.viewRadius, boundaryDir_1 );
            this.boundaryDrawer_2.DrawBoundary( this.fieldDrawer.viewRadius, boundaryDir_2 );
        }

        public void UpdateViewUI()
        {

        }
    }
}
