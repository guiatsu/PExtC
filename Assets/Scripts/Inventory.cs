using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Inventory : MonoBehaviour
{
    [SerializeField] private Item[] arrayInventory;
    
    public List<Item> _Inventory {get; private set;}

    void Awake()
    {
        _Inventory = new List<Item>();
        _Inventory = arrayInventory.OrderBy(x => x.name).ToList();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddItem(Item item){
        if(item != null)
            _Inventory.Add(item);
    }
    public void RemoveItem(Item item){
        if(item != null)
            _Inventory.Remove(item);
    }
}
