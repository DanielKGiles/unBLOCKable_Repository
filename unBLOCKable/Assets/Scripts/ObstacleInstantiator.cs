using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstantiator : MonoBehaviour
{
    public GameObject player;
    public GameObject StandardBlock;

    private int blockLocationCounter = 210;
    private bool blockPlaced = false;
    int[] blockIndex = new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 4, 4, 5 };
    private int distanceToFinishMakingInitialBlocks = 200;
    private int distanceToStartMakingInitialBlocks = 20;
    private int blockIncrementationDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        blockLocationCounter = (int)player.transform.position[0] + distanceToFinishMakingInitialBlocks;
        InstantiateInitialObstacles();
    }

    public void InstantiateInitialObstacles()
    {
        
        int instantiateLocationX = (int) player.transform.position[0] + distanceToStartMakingInitialBlocks;

        for (int blockSegmentLocation = instantiateLocationX; blockSegmentLocation < distanceToFinishMakingInitialBlocks; blockSegmentLocation += blockIncrementationDistance) 
        {
            int rowNumber = Random.Range(blockSegmentLocation, blockSegmentLocation + blockIncrementationDistance);

            //for (int numberOfblocks)
            int trackSliceNumber = Random.Range(-2, 3);

            Vector3 instantiationLocation = new Vector3(rowNumber, 1, trackSliceNumber);

            Instantiate(StandardBlock, instantiationLocation, Quaternion.identity);

        }

    }

    public void InstantiateContinuousObstacles()
    {
        

        //int instantiateLocationX = (int)player.transform.position[0] + blockCounter;
        if (blockLocationCounter + blockIncrementationDistance < player.transform.position[0] + distanceToFinishMakingInitialBlocks) 
        {
            blockLocationCounter += blockIncrementationDistance;
            blockPlaced = false;
        }
        if (blockPlaced != true) 
        {
            int rowNumber = Random.Range(blockLocationCounter, blockLocationCounter + blockIncrementationDistance);

            //for (int numberOfblocks)
            int trackSliceNumber = Random.Range(-2, 3);

            Vector3 instantiationLocation = new Vector3(rowNumber, 1, trackSliceNumber);

            Instantiate(StandardBlock, instantiationLocation, Quaternion.identity);
            blockPlaced = true;
        }        

    }

    private void FixedUpdate()
    {
        InstantiateContinuousObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
