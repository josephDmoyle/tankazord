using System.Collections.Generic;
using UnityEngine;

namespace Princeps.Player.UI
{
    public class ViewUIController : MonoBehaviour
    {
        public float viewRadius = 100.0f;

        public GameObject targetIndicatorPrefab;

        public HorizontalArcUIDrawer horizontalArcPrefab;

        public RadiusUIDrawer radiusPrefab;

        public ViewBoundaryUIDrawer boundaryDrawer_1;

        public ViewBoundaryUIDrawer boundaryDrawer_2;

        private RectTransform _testTransform;

        private List<GameObject> _curTargetIndicators;

        private int _curIndicatorIdx;

        public void Setup( float viewAngle, Vector2 boundaryDir_1, Vector2 boundaryDir_2, int fieldSize = 3 )
        {
            this.DrawFiled( fieldSize, viewAngle );
            this.boundaryDrawer_1.DrawBoundary( viewRadius, boundaryDir_1 );
            this.boundaryDrawer_2.DrawBoundary( viewRadius, boundaryDir_2 );
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
            transform.anchoredPosition = direction * ( radiusPercentage * this.viewRadius );
        }

        public void CleanTargets()
        {
            _curIndicatorIdx = 0;
            for ( int i = 0; i < _curTargetIndicators.Count; i++ )
            {
                _curTargetIndicators[i].SetActive( false );
            }
        }

        private void DrawFiled( int size, float viewAngle )
        {
            // Draw arcs
            var segmentOfRadius = this.viewRadius / size;
            float curRadius;
            var anchoredPosition = this.boundaryDrawer_1.GetComponent<RectTransform>( ).anchoredPosition;
            for ( int i = 1; i <= size; ++i )
            {
                curRadius = i * segmentOfRadius;
                // Instantiate a new arc drawer
                var arcDrawer = Instantiate<HorizontalArcUIDrawer>( this.horizontalArcPrefab );
                arcDrawer.transform.SetParent( this.transform );
                arcDrawer.GetComponent<RectTransform>( ).anchoredPosition = anchoredPosition;
                arcDrawer.DrawArc( viewAngle, curRadius );
            }

            // Draw radius;
            float angle = -viewAngle / 2;
            float segementOfAngle = viewAngle / size;
            for ( int i = 0; i < size - 1; ++i )
            {
                angle += segementOfAngle;
                // Instantiate a new radius drawer
                var radiusDrawer = Instantiate<RadiusUIDrawer>( this.radiusPrefab );
                radiusDrawer.transform.SetParent( this.transform );
                radiusDrawer.GetComponent<RectTransform>( ).anchoredPosition = anchoredPosition;
                radiusDrawer.DrawRadius( angle, this.viewRadius );
            }
        }

        private void Awake()
        {
            _curTargetIndicators = new List<GameObject>( );
            _curIndicatorIdx = 0;
        }
    }
}
