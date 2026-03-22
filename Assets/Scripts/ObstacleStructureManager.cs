using Unity.VectorGraphics;
using UnityEngine;

public class ObstacleStructureManager : MonoBehaviour
{
    [SerializeField] private GameObject topObstacle;
    [SerializeField] private GameObject bottomObstacle;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject ground;

    private float sceneHeight;
    private float groundHeight = 1f; //used to make sure obstacels spawn above ground. Will need to manually change but doubt I will want the ground to be any taller
    private float obsGap = 2f; //gap the player will need to jump through
    private float minObsSize = 2f; //currently want the smallest a obs can be to be 2 units
    
    //the largest a obs could be accounting for all other constraints. Will be used to randomly generate obs height
    private float maxObsSize; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneHeight = cam.orthographicSize * 2;

        maxObsSize = sceneHeight - obsGap - minObsSize - groundHeight;

        float bottomObsHeight = Random.Range(minObsSize, maxObsSize);
        bottomObstacle.transform.localScale = new Vector2(1, bottomObsHeight);
        bottomObstacle.transform.position = new Vector2(0, ground.transform.position.y + (bottomObsHeight / 2) + (groundHeight / 2));

        float topObsHeight = sceneHeight - obsGap - bottomObsHeight;
        topObstacle.transform.localScale = new Vector2(1, topObsHeight);
        topObstacle.transform.position = new Vector2(0, (sceneHeight / 2) - (topObsHeight / 2));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-5f, 0, 0) * Time.deltaTime;
    }
}
