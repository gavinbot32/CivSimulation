using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameSettings gameSettings;
    public int islandCount;
    public GameObject landPrefab;
    public List<LandScript> continents;
    public Vector4 bounds;
    public Vector2 landMinMaxes;

    private void Awake()
    {
        for (int i = 0; i < islandCount; i++)
        {
            LandScript land = Instantiate(landPrefab).GetComponent<LandScript>();
            land.initialize(gameSettings.climates[Random.Range(0, gameSettings.climates.Length)]);
            continents.Add(land);
            
            land.transform.position = new Vector3(Random.Range(bounds.x + (land.transform.localScale.x / 2), bounds.y - (land.transform.localScale.x / 2)),
                0, Random.Range(bounds.z + (land.transform.localScale.z / 2), bounds.w - (land.transform.localScale.z / 2)));


/*
            foreach (LandScript other in continents)
            {
               
                if (other != land)
                {
                    float distance;
                    float distThreshold;
                    bool place = false;
                    while (place == false)
                    {
                        land.transform.position = new Vector3(Random.Range(bounds.x + (land.transform.localScale.x / 2), bounds.y - (land.transform.localScale.x / 2)),
                0, Random.Range(bounds.z + (land.transform.localScale.z / 2), bounds.w - (land.transform.localScale.z / 2)));

                        float landDistVar;
                        float otherDistVar;
                        if (land.transform.localScale.x >= land.transform.localScale.z)
                        {
                            landDistVar = land.transform.localScale.x;
                        }
                        else
                        {
                            landDistVar = land.transform.localScale.z;
                        }
                        if (other.transform.localScale.x >= other.transform.localScale.z)
                        {
                            otherDistVar = other.transform.localScale.x;
                        }
                        else
                        {
                            otherDistVar = other.transform.localScale.z;
                        }

                        distThreshold = (landDistVar + otherDistVar / 2) + (landDistVar / 3);
                        distance = Vector3.Distance(land.transform.position, other.transform.position);
                        print(distThreshold);


                        if (distance > distThreshold)
                        {
                            print((land.landName, distance, other.landName, "Good Spawn"));
                            place = true;
                        }
                        else
                        {
                            print((land.landName, distance, other.landName, "Less Than Threshold"));
                        }

                    }

                }
            }*/

        }

  
            
        }
    




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

