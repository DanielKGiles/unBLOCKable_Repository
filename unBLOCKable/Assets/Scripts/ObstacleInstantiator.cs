using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstantiator : MonoBehaviour
{
    public GameObject player;
    public GameObject StandardBlock;
    public GameObject CherryPickup;

    private int blockLocationCounter = 210;
    private bool blockPlaced = false;
    int[] blockIndex = new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 4, 4, 5 };
    private int distanceToFinishMakingInitialBlocks = 200;
    private int distanceToStartMakingInitialBlocks = 20;
    private int blockIncrementationDistance = 10;
    private int probabilityToProduceDoubleStoryBlock;

    private int cherryLocationCounter = 210;
    private bool cherryPlaced = false;
    int[] cherryIndex = new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 4, 4, 5 };
    private int distanceToFinishMakingInitialCherries = 200;
    private int distanceToStartMakingInitialCherries = 20;
    private int cherryIncrementationDistance = 10;


    // Start is called before the first frame update
    void Start()
    {
        blockLocationCounter = (int)player.transform.position[0] + distanceToFinishMakingInitialBlocks;
        cherryLocationCounter = (int)player.transform.position[0] + distanceToFinishMakingInitialBlocks;
        InstantiateInitialObstacles();
        InstantiateInitialCherries();
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

            float placeAdditionalBlockOnTop = Random.Range(0, 100);
            if (placeAdditionalBlockOnTop > probabilityToProduceDoubleStoryBlock)
            {
                Instantiate(StandardBlock, new Vector3(instantiationLocation[0], 2, instantiationLocation[2]), Quaternion.identity);
            }
        }        

    }
    public void InstantiateInitialCherries()
    {

        int instantiateLocationX = (int)player.transform.position[0] + distanceToStartMakingInitialCherries;

        for (int blockSegmentLocation = instantiateLocationX; blockSegmentLocation < distanceToFinishMakingInitialCherries; blockSegmentLocation += cherryIncrementationDistance)
        {
            int rowNumber = Random.Range(blockSegmentLocation, blockSegmentLocation + cherryIncrementationDistance);

            //for (int numberOfblocks)
            int trackSliceNumber = Random.Range(-2, 3);

            Vector3 instantiationLocation = new Vector3(rowNumber, 1, trackSliceNumber);

            Instantiate(CherryPickup, instantiationLocation, Quaternion.identity);

        }

    }
    public void InstantiateContinuousCherries()
    {
        

        //int instantiateLocationX = (int)player.transform.position[0] + blockCounter;
        if (cherryLocationCounter + cherryIncrementationDistance < player.transform.position[0] + distanceToFinishMakingInitialCherries)
        {
            cherryLocationCounter += cherryIncrementationDistance;
            cherryPlaced = false;
        }
        if (cherryPlaced != true)
        {
            int rowNumber = Random.Range(cherryLocationCounter, cherryLocationCounter + cherryIncrementationDistance);

            //for (int numberOfblocks)
            int trackSliceNumber = Random.Range(-2, 3);

            Vector3 instantiationLocation = new Vector3(rowNumber, 1, trackSliceNumber);

            Instantiate(CherryPickup, new Vector3(instantiationLocation[0], 2, instantiationLocation[2]), Quaternion.identity);
            cherryPlaced = true;
        }

    }

    //public void RemoveUnusedStandardBlocks
    //{
    //    if 
    //}

    private void FixedUpdate()
    {
        InstantiateContinuousObstacles();
        InstantiateContinuousCherries();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
