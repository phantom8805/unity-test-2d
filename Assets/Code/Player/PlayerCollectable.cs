using UnityEngine;
using UnityEngine.UI;

public class PlayerCollectable : MonoBehaviour
{
    private int _collectedCount;

    [SerializeField] private GameObject[] objectsToSpawn;

    [SerializeField] private Transform parent;

    [SerializeField] private Text textValue;

    void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            RandomSpawn(-15, 15, 0, 2);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            _collectedCount++;
            Destroy(other.gameObject);

            textValue.text = _collectedCount.ToString();
        }
    }

    private void RandomSpawn(float minX, float maxX, float minY, float maxY)
    {
        Vector2 pos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        GameObject goodsPrefab = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        Instantiate(goodsPrefab, pos, Quaternion.identity, parent);
    }
}