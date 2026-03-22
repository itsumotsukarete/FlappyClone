using UnityEngine;

public class ObstacleStructureManager : MonoBehaviour
{
    [SerializeField] private GameObject topObstacle;
    [SerializeField] private GameObject bottomObstacle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        topObstacle.transform.position = new Vector2(0, 3f);
        bottomObstacle.transform.position = new Vector2(0f, -3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-5f, 0, 0) * Time.deltaTime;
    }
}
