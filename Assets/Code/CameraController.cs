using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    private void Update()
    {
        Vector3 playerPosition = player.position;
        transform.position = new Vector3(playerPosition.x, 0, -10);
    }
}