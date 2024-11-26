using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(PlayerController))]
    public class Player : MonoBehaviour
    {
        private Animator _animator;
        
        private const int MaxHealth = 100;
        private const int MinHealth = 0;
        
        private int _currentHealth;
        
        private bool IsDead => 0 >= _currentHealth;
        
        private const string HitAnimation = "hit";
        private const string DeathAnimation = "die";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _currentHealth = MaxHealth;
        }
        public void GetDamage(int damage)
        {
            // эта проверка нужна, чтобы враг не смог атаковать игрока, когда у него 0 хп и не сбилась анимация смерти
            if (_currentHealth > 0)
            {
                _currentHealth = damage >= _currentHealth ? MinHealth : _currentHealth - damage;

                if (IsDead)
                {
                    StartCoroutine(Death());
                }
                else
                {
                    _animator.SetTrigger(HitAnimation);
                }
            }
        }

        private IEnumerator Death()
        {
            _animator.SetTrigger(HitAnimation);
            _animator.SetBool(DeathAnimation, true);
            yield return new WaitForSeconds(2.5f);
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Coin coin))
            {
                Destroy(coin.gameObject);
            }
        }
    }
}
