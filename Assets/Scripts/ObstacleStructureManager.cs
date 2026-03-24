using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleStructureManager : MonoBehaviour
{
    [SerializeField] private GameObject topObstacle;
    [SerializeField] private GameObject bottomObstacle;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject ground;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform despawnPoint;

    private float sceneHeight;
    private float groundHeight = 1f; //used to make sure obstacels spawn above ground. Will need to manually change but doubt I will want the ground to be any taller
    private float obsGap = 3f; //gap the player will need to jump through
    private float minObsSize = 2f; //currently want the smallest a obs can be to be 2 units
    
    //the largest a obs could be accounting for all other constraints. Will be used to randomly generate obs height
    private float maxObsSize; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneHeight = cam.orthographicSize * 2;

        maxObsSize = sceneHeight - obsGap - minObsSize - groundHeight;

        float bottomObsHeight = Random.Range((int) minObsSize, (int) maxObsSize);
        bottomObstacle.transform.localScale = new Vector2(1, bottomObsHeight);
        bottomObstacle.transform.position = new Vector2(spawnPoint.position.x, ground.transform.position.y + (bottomObsHeight / 2) + (groundHeight / 2));

        float topObsHeight = sceneHeight - obsGap - bottomObsHeight;
        topObstacle.transform.localScale = new Vector2(1, topObsHeight);
        topObstacle.transform.position = new Vector2(spawnPoint.position.x, (sceneHeight / 2) - (topObsHeight / 2));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 3 * Time.deltaTime);

        if (bottomObstacle.transform.position.x < despawnPoint.position.x)
        {
            Debug.Log("Destroying Gameobject at " + transform.position.ToString());
            Destroy(this.gameObject);
        }
    }
}
