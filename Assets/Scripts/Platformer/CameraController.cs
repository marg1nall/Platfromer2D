using UnityEngine;

namespace Platformer
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float offsetY = 2.5f;
        [SerializeField] private float offsetX = 2f;

        void Update()
        {
            transform.position = new Vector3(_target.position.x + offsetX, _target.position.y + offsetY,
                transform.position.z);
        }
    }
}
