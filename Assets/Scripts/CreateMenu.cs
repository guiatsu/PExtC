using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMenu : MonoBehaviour
{
    public ItemReference _element;
    private List<Item> _Inventory;
    [SerializeField] private GameObject inventoryObject;

    // Start is called before the first frame update
    void Start()
    {
        _Inventory = new List<Item>();
        _Inventory = inventoryObject.GetComponent<Inventory>()._Inventory;


        InstantiateElements();
        // FindObjectOfType<Inventory>().RemoveItem(_Inventory[0]);
    }

    // Update is called once per frame

    void InstantiateElements(){
        if(_Inventory.Count == 0)
            return;
        foreach(Item item in _Inventory){
            (Instantiate(_element, transform) as ItemReference).SetValues(item);
        }
    }
}
