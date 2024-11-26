using System;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public class CheckPlayer : MonoBehaviour
    {
        public event UnityAction<Player> OnPlayerEnter;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                OnPlayerEnter?.Invoke(player);
            }
        }
    }
}
