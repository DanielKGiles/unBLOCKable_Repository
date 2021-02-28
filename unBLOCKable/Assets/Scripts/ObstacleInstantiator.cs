using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInstantiator : MonoBehaviour
{
    public GameObject player;
    public GameObject StandardBlock;


    // Start is called before the first frame update
    void Start()
    {
        InstantiateInitialObjects();
    }

    public void InstantiateInitialObjects()
    {
        
        int instantiateLocationX = (int) player.transform.position[0] + 20;

        int[] blockIndex = new int[] {0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 4, 4, 5 };

        for (int blockSegmentLocation = instantiateLocationX; blockSegmentLocation < 200; blockSegmentLocation += 10) 
        {
            Debug.Log("Instantiating an Object");
            int rowNumber = Random.Range(blockSegmentLocation, blockSegmentLocation + 10);

            //for (int numberOfblocks)
            int trackSliceNumber = Random.Range(-2, 3);

            Vector3 instantiationLocation = new Vector3(rowNumber, 1, trackSliceNumber);

            Instantiate(StandardBlock, instantiationLocation, Quaternion.identity);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
