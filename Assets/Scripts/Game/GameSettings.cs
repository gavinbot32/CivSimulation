using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 0)]
public class GameSettings : ScriptableObject
{
    public string[] prefixes;
    public string[] suffixes;
    public string[] centres;

    public Climate[] climates;

}
