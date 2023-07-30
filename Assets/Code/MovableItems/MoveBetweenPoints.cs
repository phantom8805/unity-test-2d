using UnityEngine;

namespace Base.MoveableItems
{
    public class MoveBetweenPoints : MonoBehaviour
    {

        [SerializeField] private float horizontalSpeed = 2f;

        [SerializeField] private GameObject startPoint;
        [SerializeField] private GameObject endPoint;

        private bool _moveIsReverse;

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
}
