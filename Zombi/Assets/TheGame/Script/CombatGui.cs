using UnityEngine;
using System.Collections;

public class CombatGui : MonoBehaviour
{
    PlayerStats _playerStats;

    PHealth _playerHealth; // Health yerine PHealth1 kullanýyoruz

    [SerializeField] Texture2D _gameOverImage;

    [SerializeField] Texture2D _winImage;
    void Start()
    {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        
        if (playerGameObject != null)
        {
            _playerHealth = playerGameObject.GetComponent<PHealth>(); // PHealth1 bileþenini al
            _playerStats = playerGameObject.GetComponent<PlayerStats>();

            if (_playerHealth == null)
            {
                Debug.LogWarning("PHealth1 component not found on Player!");
            }
        }
        else
        {
            Debug.LogWarning("Player GameObject not found!");
        }
    }

    void OnGUI()
    {
        if (_playerHealth != null && _playerHealth.isDead) // IsDead yerine isDead kullanýyoruz
        {
            float x = (Screen.width - _gameOverImage.width) / 2;
            float y = (Screen.height - _gameOverImage.height) / 2;
            GUI.DrawTexture(new Rect(x, y, _gameOverImage.width, _gameOverImage.height), _gameOverImage);
            GUI.Label(new Rect(x + 100, y + 280, 100, 100), "Zombies killed: " + _playerStats.ZombiesKilled);
        }
        else if (GameManager.HasPlayerWon)
        {
            float x = (Screen.width - _winImage.width) / 2;
            float y = (Screen.height - _winImage.height) / 2;
            GUI.DrawTexture(new Rect(x, y, _winImage.width, _winImage.height), _winImage);
            GUI.Label(new Rect(x + 100, y + 280, 100, 100), "Zombies killed: " + _playerStats.ZombiesKilled);
        }
    }
}