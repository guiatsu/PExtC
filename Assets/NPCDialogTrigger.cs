using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public bool playerInRange = false;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        playerInRange = true;
    }
    private void OnTriggerExit2D(Collider2D other){
        playerInRange = false;
    }
}
