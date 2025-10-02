using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    float _secondsToWin = 30.0f;
    static bool _hasPlayerWon = false;
    public static bool HasPlayerWon { get { return _hasPlayerWon; } }

    public static void WinPlayer()
    {
        _hasPlayerWon = true;
    }

    PHealth _playerHealth;
    CharacterController _playerController;
    void Start()
    {
        Invoke("CheckWin", _secondsToWin);
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _playerHealth = playerGameObject.GetComponent<PHealth>();
        _playerController = playerGameObject.GetComponent<CharacterController>(); // Or GetComponent<PlayerMovement>()
    }

    void CheckWin()
    {

        if (!_playerHealth.isDead)
        {
            _hasPlayerWon = true;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            foreach (GameObject enemy in enemies)
            {
                Animation enemyAnimation = enemy.GetComponentInChildren<Animation>();

                if (enemyAnimation != null)
                {
                    enemyAnimation.Stop();
                }
                Destroy(enemy.GetComponent<EA1>());
                Destroy(enemy.GetComponent<EnemyAttack>());
                Destroy(enemy.GetComponent<EM2>());
            }


            Destroy(_playerController);
            // EnemySpawnManager3 objesini bul ve yok et
            GameObject esmObject = Object.FindFirstObjectByType<EnemySpawnManager>()?.gameObject;
            Destroy(esmObject);
        }

    }
}