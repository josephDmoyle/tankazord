using System;
using UnityEditor;
using UnityEngine;

namespace Princeps.Player
{
    [CustomEditor( typeof( TargetManager ) )]
    public class TargetManagerEditor : Editor
    {
        private TargetManager _manager;

        private void OnEnable()
        {
            if ( _manager == null )
            {
                _manager = (TargetManager)target;
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI( );
            this.DisplayTargets( );
            if ( GUILayout.Button( "Generate Targets" ) )
            {
                // Use a fixed size as testing.
                if ( _manager.view == null )
                {
                    throw new Exception( "If you want to generate targets, please assign the 'view' firstly." );
                }
                this.GenerateTargets( 3 );
            }
            if ( GUILayout.Button( "Clear Targets" ) )
            {
                this.ClearTargets( );
            }
            if ( GUI.changed )
            {
                EditorUtility.SetDirty( _manager );
            }
        }

        private void DisplayTargets()
        {
            EditorGUILayout.BeginVertical( );
            EditorGUILayout.LabelField( "Targets" );
            ++EditorGUI.indentLevel;
            for ( int i = 0; i < _manager.targetPoints.Count; i++ )
            {
                if ( _manager.targetPoints[i] != null )
                {
                    EditorGUILayout.LabelField( _manager.targetPoints[i].name );
                }
            }
            --EditorGUI.indentLevel;
            EditorGUILayout.EndVertical( );
        }

        private void GenerateTargets( uint size )
        {
            // Clear the previous one
            this.ClearTargets( );
            float startAngle = _manager.view.viewAngle / ( size * 2 ) - _manager.view.viewAngle / 2;
            var segmentOfAngle = _manager.view.viewAngle / size;
            var segmentOfRadius = _manager.view.viewRadius / size;
            Vector3 dir = Vector2.zero;
            Vector3 posOfTarget;
            float angle;
            int counter = 1;

            for ( int i = 0; i < size; i++ )
            {
                angle = startAngle + i * segmentOfAngle;
                dir = _manager.view.DirectionFromAngle( angle, false );
                posOfTarget = _manager.transform.position + dir * ( segmentOfRadius / 2 );
                for ( int j = 0; j < size; j++ )
                {
                    var newTarget = new GameObject( );
                    newTarget.name = "Target_" + counter;
                    var targetTransform = newTarget.GetComponent<Transform>( );
                    targetTransform.SetParent( _manager.transform );
                    targetTransform.position = posOfTarget;
                    _manager.targetPoints.Add( targetTransform );

                    ++counter;
                    posOfTarget += ( dir * segmentOfRadius );
                }
            }
        }

        private void ClearTargets()
        {
            if ( _manager.targetPoints.Count != 0 )
            {
                for ( int i = _manager.targetPoints.Count - 1; i >= 0; i-- )
                {
                    if ( _manager.targetPoints[i] == null )
                    {
                        _manager.targetPoints.RemoveAt( i );
                    }
                    else
                    {
                        var removeGameObject = _manager.targetPoints[i].gameObject;
                        _manager.targetPoints.RemoveAt( i );
                        Destroy( removeGameObject );
                    }
                }
            }
        }
    }
}
