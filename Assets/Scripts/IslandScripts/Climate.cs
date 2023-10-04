using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Climate", menuName = "ScriptableObjects/Climate", order = 1)]
public class Climate : ScriptableObject
{
    public string climate_name;
    public int tempature_level;
    public int animal_level;
    public int fish_level;
    public int tree_level;
    public int mineral_level;
    public int moisture_level;

    public Material climate_mat;
}
