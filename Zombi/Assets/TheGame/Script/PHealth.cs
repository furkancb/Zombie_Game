using UnityEngine;
using System.Collections;

public class PHealth : MonoBehaviour
{
    [SerializeField] int _maximumHealth = 100;

    [SerializeField]
    int _currentHealth = 0;

    [SerializeField]
    AudioClip _hitSound;
    private AudioSource _audioSource;

    [SerializeField]
    AudioClip _deathSound;

    public override string ToString()
    {
        return _currentHealth + "/" + _maximumHealth;
    }
    public bool isDead
    {
        get { return _currentHealth <= 0; }
    }

    void Start()
    {
        _currentHealth = _maximumHealth;

        _audioSource = GetComponent<AudioSource>();
    }

    public void Damage(int damageValue)
    {
        _currentHealth -= damageValue;

        if (_currentHealth <= 0)
        {
            if (_deathSound != null)
            {
                _audioSource.clip = _deathSound;
                _audioSource.Play();
            }
            Animator a = GetComponentInChildren<Animator>();

            a.enabled = false; // Animator'ı devre dışı bırak

            Destroy(GetComponent<PM4>());
            Destroy(GetComponent<PlayerAnimation>());
            Destroy(GetComponent<EM2>());
            Destroy(GetComponent<RW3>());
            Destroy(GetComponent<LookX>());

            Destroy(GetComponent<CharacterController>());

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
            GameObject esmObject = Object.FindFirstObjectByType<EnemySpawnManager>()?.gameObject;
            Destroy(esmObject);
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