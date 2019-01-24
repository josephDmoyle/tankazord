using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTime = 5f;
    float timer = 0f;

    public List<Transform> spawnPoints;

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if ( timer > spawnTime )
        {
            var spawnPoint = this.spawnPoints[Random.Range( 0, this.spawnPoints.Count )];
            Instantiate( enemy, spawnPoint.position, spawnPoint.rotation );
            timer = 0f;
        }
    }
}
