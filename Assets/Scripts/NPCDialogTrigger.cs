using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public bool playerInRange;
    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player"))
            playerInRange = true;
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player"))
            playerInRange = false;
    }
}
