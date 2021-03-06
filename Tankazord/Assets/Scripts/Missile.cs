﻿using System.Linq;
using UnityEngine;

namespace Princeps.Player
{
    public class Missile : MonoBehaviour
    {
        public float explosionRadius;

        public float instantiateHeight;

        private void OnCollisionEnter( Collision collision )
        {
            // Package two layers together
            var bitLayerMask_Ground = 1 << LayerMask.NameToLayer( "Ground" );
            var bitLayerMask_Target = 1 << LayerMask.NameToLayer( "Target" );
            var combineLayerMask = bitLayerMask_Ground | bitLayerMask_Target;
            var colliderLayerMask = 1 << collision.collider.gameObject.layer;
            if ( ( colliderLayerMask & combineLayerMask ) != 0 )
            {
                var collidersInSphere = Physics.OverlapSphere( this.transform.position, this.explosionRadius, bitLayerMask_Target ).ToList( );
                for ( int i = collidersInSphere.Count - 1; i >= 0; --i )
                {
                    var curCollider = collidersInSphere[i];
                    if ( curCollider != null )
                    {
                        collidersInSphere.RemoveAt( i );
                    }
                    if ( curCollider.gameObject != null )
                    {
                        var health = curCollider.gameObject.GetComponent<Health>( );
                        if ( health != null )
                        {
                            curCollider.gameObject.GetComponent<Health>( ).Damage( 10f );
                        }
                        else
                        {
                            Destroy( curCollider.gameObject );
                        }
                    }
                }
                Destroy( this.gameObject );
            }
        }
    }
}