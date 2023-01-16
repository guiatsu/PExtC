using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : NPC
{

    // Start is called before the first frame update
    [SerializeField] List<Item> _Inventory;
    [SerializeField] GameObject _InventoryWindow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NPCDialogTrigger trigger = dialogTrigger.GetComponent<NPCDialogTrigger>();
        // // Check if player is in a certain radius and presses the space bar then opens dialog if its closed
        // if (Input.GetKeyDown(KeyCode.Space) && !dialogBox.activeSelf && trigger.playerInRange)
        // {
        //     Dialog dialogbox = dialogBox.GetComponent<Dialog>();
        //     dialogbox.ShowDialog(dialogLines, characterName);
        // }
        if (Input.GetKeyDown(KeyCode.Space) && _InventoryWindow.activeSelf)
        {
            _InventoryWindow.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && !_InventoryWindow.activeSelf && trigger.playerInRange)
        {
            _InventoryWindow.SetActive(true);
        }
    }

}
