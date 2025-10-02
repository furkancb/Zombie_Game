using UnityEngine;
using System.Collections;
public class EnemySpawnManager : MonoBehaviour
{
    static int _livingZombies = 0;
    static public void OnEnemyDeath()
    
    {
        --_livingZombies;
        Debug.Log($"Enemy died! Living zombies: {_livingZombies}");
    }

    [SerializeField]
    GameObject _enemyToSpawn;

    [SerializeField]
    float _spawnDelay = 1.0f;

    [SerializeField]
    int _enemyLimit = 30;

    float _nextSpawnTime = -1.0f;

    [SerializeField]
    LayerMask _spawnLayer;

    void Update()
    {
        if (GameManager.HasPlayerWon)
        {
            Destroy(this);
            return;
        }

        if (Time.time >= _nextSpawnTime && _livingZombies < _enemyLimit)
        {
            Vector3 edgeOfScreen = new Vector3(1.25f, Random.value, 8.0f);

            if (Random.value > 0.5f)
            {
                edgeOfScreen.x = -0.25f;
            }

            Ray ray = Camera.main.ViewportPointToRay(edgeOfScreen);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _spawnLayer.value))
            {
                Vector3 placeToSpawn = hit.point;
                Quaternion directionToFace = Quaternion.identity;
                Instantiate(_enemyToSpawn, placeToSpawn, directionToFace);
                _nextSpawnTime = Time.time + _spawnDelay;
                ++_livingZombies;
                Debug.Log($" Living zombies: {_livingZombies}");
            }
        }
    }
}
