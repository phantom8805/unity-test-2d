using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
        }
    }
}
