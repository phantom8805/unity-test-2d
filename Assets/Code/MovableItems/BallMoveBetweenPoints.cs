using UnityEngine;
public class BallMoveBetweenPoints : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float speed = 80f;

    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;

    private bool _moveIsReverse;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GameObject targetPoint = _moveIsReverse ? endPoint : startPoint;

        float distance = Vector2.Distance(
            new Vector2(_rigidbody2D.position.x, 0f),
            new Vector2(targetPoint.transform.position.x, 0f)
        );
        if (distance < 0.1f)
        {
            _moveIsReverse = !_moveIsReverse;
        }

        float rotationAngle = speed * Time.fixedDeltaTime * (_moveIsReverse ? -1 : 1);
        Quaternion quaternion = Quaternion.Euler(0, 0, _rigidbody2D.rotation + rotationAngle);

        _rigidbody2D.MoveRotation(quaternion);
    }
}