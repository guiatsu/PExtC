using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMenu : MonoBehaviour
{
    public ItemReference _element;
    private List<Item> _Inventory;

    // Start is called before the first frame update
    void Start()
    {
        _Inventory = new List<Item>();
        _Inventory = FindObjectOfType<Inventory>()._Inventory;
        InstantiateElements();
        FindObjectOfType<Inventory>().RemoveItem(_Inventory[0]);
    }

    // Update is called once per frame

    void InstantiateElements(){
        foreach(Item item in _Inventory){
            (Instantiate(_element, transform) as ItemReference).SetValues(item);
        }
    }
}
