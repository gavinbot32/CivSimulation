using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
public class LandScript : MonoBehaviour
{
    public GameSettings gameSettings;
    public GameManager manager;
    private Vector4 bounds;

    public string landName;
    public Climate climate;
    private MeshRenderer mr;

    private NavMeshSurface surface;
    bool navmeshBuilt = false;
    float timeSinceCol;
    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        manager = FindObjectOfType<GameManager>();
        bounds = manager.bounds;
        timeSinceCol = 0;
        surface = GetComponent<NavMeshSurface>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!navmeshBuilt)
        {
            genNavMesh();
        }
     
        


    }

    public void genNavMesh()
    {        
        timeSinceCol += Time.deltaTime;
        if(timeSinceCol >= 1f)
        {
            surface.BuildNavMesh();
            navmeshBuilt = true;
        }
    }


    public void genTrees()
    {
        int treeCount = Mathf.RoundToInt(climate.tree_level * (((transform.localScale.x + transform.localScale.z)/2) / 3));
        print(("Tree Count", treeCount, landName));

        for (int i = 0; i < treeCount; i++)
        {
            int ind = Random.Range(0, climate.trees.Length);

            float minxBound = (transform.position.x - (transform.localScale.x / 2));
            float maxxBound = (transform.position.x + (transform.localScale.x / 2));

            float minzBound = (transform.position.z - (transform.localScale.z / 2));
            float maxzBound = (transform.position.z + (transform.localScale.z / 2));
            GameObject tree = Instantiate(climate.trees[ind],new Vector3(Random.Range(minxBound,maxxBound),0.5f,Random.Range(minzBound,maxzBound)),Quaternion.identity);
            tree.transform.parent = transform;
        }
    }

    public void initialize(Climate cli) {
        transform.localScale = new Vector3(Random.Range(manager.landMinMaxes.x, manager.landMinMaxes.y), 2, Random.Range(manager.landMinMaxes.x, manager.landMinMaxes.y));
        climate = cli;
        mr.material = climate.climate_mat;
        landName = nameGen();
        name = landName;

        genTrees();
    }
    string nameGen()
    {
        string ret;
        string pre;
        string mid;
        string suf;

        pre = gameSettings.prefixes[Random.Range(0, gameSettings.prefixes.Length)];
        mid = gameSettings.centres[Random.Range(0, gameSettings.centres.Length)];
        suf = gameSettings.suffixes[Random.Range(0, gameSettings.suffixes.Length)];
        ret = pre+ mid + suf;
        return ret;
    }


    private void OnTriggerEnter(Collider other)
    {
        print("Land Ho");
        if (other.gameObject.CompareTag("Continent"))
        {
            timeSinceCol = 0;
            transform.position = new Vector3(Random.Range(bounds.x + transform.localScale.x, bounds.y - transform.localScale.x),
               0, Random.Range(bounds.z + transform.localScale.z, bounds.w - transform.localScale.z));
        }
    }


}
