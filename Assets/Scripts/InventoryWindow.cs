using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWindow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject inventory;
    void Start()
    {
        inventory.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
            inventory.SetActive(!inventory.activeSelf);
        //log the active state of the gameObject
    }
}
