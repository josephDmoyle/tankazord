using System.Collections.Generic;
using UnityEngine;

namespace Princeps.Player
{
    public class ViewUIController : MonoBehaviour
    {
        public FieldOfViewUIDrawer fieldDrawer;

        public GameObject targetIndicatorPrefab;

        public ViewBoundaryUIDrawer boundaryDrawer_1;

        public ViewBoundaryUIDrawer boundaryDrawer_2;

        private RectTransform _testTransform;

        private List<GameObject> _curTargetIndicators;

        private int _curIndicatorIdx;

        public void Setup( float viewAngle, Vector2 boundaryDir_1, Vector2 boundaryDir_2 )
        {
            this.fieldDrawer.DrawField( viewAngle );
            this.boundaryDrawer_1.DrawBoundary( this.fieldDrawer.viewRadius, boundaryDir_1 );
            this.boundaryDrawer_2.DrawBoundary( this.fieldDrawer.viewRadius, boundaryDir_2 );
        }

        public void DrawTarget( Vector2 direction, float radiusPercentage )
        {
            if ( _curIndicatorIdx >= _curTargetIndicators.Count )
            {
                var newIndicator = Instantiate( targetIndicatorPrefab );
                newIndicator.transform.SetParent( this.transform );
                _curTargetIndicators.Add( newIndicator );
            }
            var indicator = _curTargetIndicators[_curIndicatorIdx++];
            indicator.SetActive( true );
            var transform = indicator.GetComponent<RectTransform>( );
            transform.anchoredPosition = direction * ( radiusPercentage * this.fieldDrawer.viewRadius );
        }

        public void CleanTargets()
        {
            _curIndicatorIdx = 0;
            for ( int i = 0; i < _curTargetIndicators.Count; i++ )
            {
                _curTargetIndicators[i].SetActive( false );
            }
        }

        private void Awake()
        {
            _curTargetIndicators = new List<GameObject>( );
            _curIndicatorIdx = 0;
        }
    }
}
