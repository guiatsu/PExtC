using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//scriptable object item script
[CreateAssetMenu(fileName = "New Item", menuName = "Create Item")]

public class Item : ScriptableObject
{
    public string _name;
    [TextArea(3, 10)]
    public string description;
    public string type;

    public float value;
    //list all stats used in player
    public Dictionary<string, float> stats = new Dictionary<string, float>{
        {"strength", 0},
        {"dexterity", 0},
        {"constitution", 0},
        {"intelligence", 0},
        {"wisdom", 0},
        {"charisma", 0},
        {"health", 0},
        {"mana", 0},
        {"attack", 0},
        {"defense", 0},
        {"speed", 0}
    };


    public bool isEquiped;
    public Sprite icon;
    public int ID {get; private set;}
    private void OnEnable()
    {
        ID = GetInstanceID();
    }


    
   
}
