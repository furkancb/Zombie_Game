using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float _nextTimeAttackIsAllowed = -1.0f;

    [SerializeField] float _attackDelay = 1.0f;

    [SerializeField] int _damageDealt = 5;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Time.time >= _nextTimeAttackIsAllowed)
        {
            PHealth playerHealth = other.GetComponent<PHealth>();
            playerHealth.Damage(_damageDealt);
            _nextTimeAttackIsAllowed = Time.time + _attackDelay;
        }
    }
}
