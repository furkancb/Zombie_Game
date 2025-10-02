using UnityEngine;
using System.Collections;
public class Health1 : MonoBehaviour
{
    [SerializeField] int _maximumHealth = 100;
    [SerializeField] int _currentHealth = 0;
    override public string ToString()
    {
        return _currentHealth + " / " + _maximumHealth;
    }

    public bool IsDead { get { return _currentHealth <= 0; } }
    PlayerStats _playerStats;

    [SerializeField]
    AudioClip _hitSound;
    private AudioSource _audioSource;

    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _currentHealth = _maximumHealth;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerStats = player.GetComponent<PlayerStats>();
    }

    public void Damage(int damageValue)
    {
        _currentHealth -= damageValue;

        if (_currentHealth <= 0)
        {
            _playerStats.ZombiesKilled++;
            Debug.Log(_playerStats.ZombiesKilled + "Zombi öldü");
            EnemySpawnManager.OnEnemyDeath();

            Destroy(gameObject);
        }
        else
        {
            if (_hitSound != null)
            {
                _audioSource.clip = _hitSound;
                _audioSource.Play();
            }

        }
    }
}