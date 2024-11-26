using System;
using UnityEngine;

namespace Platformer
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private CheckPlayer _checkPlayer;
        
        private const int Damage = 35;
        private const float Reload = 0.5f;
        private const float JumpForce = 6f;
        
        private float _timeToAttack;
        
        private void OnEnable()
        {
            _checkPlayer.OnPlayerEnter += StartAtack;
        }
        
        private void OnDisable()
        {
            _checkPlayer.OnPlayerEnter -= StartAtack;
        }

        private void Update()
        {
            _timeToAttack += Time.deltaTime;
        }

        private void StartAtack(Player player)
        {
            if (player is not null)
            {
                Attack(player);
            }
        }
        
        private void Attack(Player player)
        {
            if (_timeToAttack >= Reload)
            {
                player.GetDamage(Damage);
                player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                _timeToAttack = 0;
            }
        }
    }
}