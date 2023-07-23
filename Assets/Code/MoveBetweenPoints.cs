using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    private BoxCollider2D _collider;

    [SerializeField] private float horizontalSpeed = 2f;

    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject endPoint;

    private bool _moveIsReverse;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        GameObject targetPoint = _moveIsReverse ? endPoint : startPoint;

        if (Vector2.Distance(transform.position, targetPoint.transform.position) < 0.1f)
        {
            _moveIsReverse = !_moveIsReverse;
        }

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPoint.transform.position,
            horizontalSpeed * Time.deltaTime
        );
    }
}