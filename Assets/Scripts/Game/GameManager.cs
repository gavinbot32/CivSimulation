using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            land.transform.position = new Vector3(Random.Range(bounds.x + land.transform.localScale.x, bounds.y - land.transform.localScale.x),
                0, Random.Range(bounds.z + land.transform.localScale.z, bounds.w - land.transform.localScale.z));

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
