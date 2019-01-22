using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTime = 5f;
    float timer = 0f;

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > spawnTime)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            timer = 0f;
        }
    }
}
