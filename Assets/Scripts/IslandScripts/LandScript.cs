using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        manager = FindObjectOfType<GameManager>();
        bounds = manager.bounds;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initialize(Climate cli) {
        transform.localScale = new Vector3(Random.Range(manager.landMinMaxes.x, manager.landMinMaxes.y), 2, Random.Range(manager.landMinMaxes.x, manager.landMinMaxes.y));
        climate = cli;
        mr.material = climate.climate_mat;
        landName = nameGen();
        name = landName;
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

            transform.position = new Vector3(Random.Range(bounds.x + transform.localScale.x, bounds.y - transform.localScale.x),
               0, Random.Range(bounds.z + transform.localScale.z, bounds.w - transform.localScale.z));
        }
    }


}
