using System;
using UnityEngine;

namespace Platformer
{
    public class Enemy : MonoBehaviour
    {
        private const int Damage = 35;
        private const float RadiusAttack = 0.45f;
        private const float Reload = 1.5f;
        
        private float timeToAttack;

        private void Update()
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, RadiusAttack, LayerMask.GetMask("Player"));

            timeToAttack += Time.deltaTime;

            if (collider is not null)
            {
                if (timeToAttack >= Reload && collider.TryGetComponent(out Player player))
                {
                    player.GetDamage(Damage);
                    timeToAttack = 0;
                }
            }
        }
    }
}