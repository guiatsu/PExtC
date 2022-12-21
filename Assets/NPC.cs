using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // dialog lines and character name
    [SerializeField] private string[] dialogLines;
    [SerializeField] private string characterName;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject dialogTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NPCDialogTrigger trigger = dialogTrigger.GetComponent<NPCDialogTrigger>();
        // Check if player is in a certain radius and presses the space bar then opens dialog if its closed
        if (Input.GetKeyDown(KeyCode.Space) && !dialogBox.activeSelf && trigger.playerInRange)
        {
            Dialog dialogbox = dialogBox.GetComponent<Dialog>();
            dialogbox.ShowDialog(dialogLines, characterName);
        }
        
    }
}
