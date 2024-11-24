using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform _path;

        private Transform[] _points;
        private const int MinimalIndex = -1;
        private const float Speed = 1;

        private void Awake()
        {
            _points = new Transform[_path.childCount];

            for (int i = 0; i < _points.Length; i++)
            {
                _points[i] = _path.GetChild(i);
            }

            StartCoroutine(Move());
        }


        private IEnumerator Move()
        {
            for (int i = 0; i < _points.Length; i++)
            {
                while (transform.position != _points[i].position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _points[i].position, Speed * Time.deltaTime);
                    yield return null;
                }

                i = (i + 1).Equals(_points.Length) ? MinimalIndex : i;
            }

            yield return null;
        }
    }
}
