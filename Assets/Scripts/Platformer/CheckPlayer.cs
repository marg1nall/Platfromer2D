using System;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    public class CheckPlayer : MonoBehaviour
    {
        public event UnityAction<Player> OnPlayerEnter;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player player))
            {
                OnPlayerEnter?.Invoke(player);
            }
        }
    }
}
