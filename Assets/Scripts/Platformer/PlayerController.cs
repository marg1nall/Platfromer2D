using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _jumpForce = 10;

        private Rigidbody2D _rb;
        private Animator _animator;

        private Transform _checkerGround;
        
        private const float RadiusGround = 0.2f;
        
        private const string GroundObject = "CheckerGround";
        private const string GroundLayer = "Ground";
        private const string SpeedAnimation = "speed";
        private const string JumpAnimation = "jump";

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();

            _checkerGround = transform.Find(GroundObject);

            if (_checkerGround is null)
                Debug.Log("CheckerGround is null");
        }

        private void Update()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            var horizontal = Input.GetAxis("Horizontal");

            _rb.velocity = new Vector2(horizontal * _speed, _rb.velocity.y);
            _animator.SetFloat(SpeedAnimation, Mathf.Abs(horizontal));

            if (horizontal > 0)
            {
                transform.localScale = Vector3.one;
            }
            else if (horizontal < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        private void Jump()
        {
            Collider2D ground =
                Physics2D.OverlapCircle(_checkerGround.position, RadiusGround, LayerMask.GetMask(GroundLayer));

            Debug.DrawRay(_checkerGround.position, Vector2.down * RadiusGround, Color.red);

            if (ground is not null && Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(new Vector2(0, _rb.velocity.y + _jumpForce), ForceMode2D.Impulse);
                _animator.SetTrigger(JumpAnimation);
            }
        }
    }
}