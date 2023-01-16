using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // dialog lines and character name
    [SerializeField] public string[] dialogLines;
    [SerializeField] public string characterName;
    [SerializeField] public GameObject dialogBox;
    [SerializeField] public GameObject dialogTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NPCDialogTrigger trigger = dialogTrigger.GetComponent<NPCDialogTrigger>();
        // Check if player is in a certain radius and presses the space bar then opens dialog if its closed
        if (Input.GetKeyDown(KeyCode.Space) && !dialogBox.activeSelf && trigger.playerInRange && (dialogLines.Length > 0))
        {
            Dialog dialogbox = dialogBox.GetComponent<Dialog>();
            dialogbox.ShowDialog(dialogLines, characterName);
        }
        
    }
}
