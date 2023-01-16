using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private TMP_Text headText;

    [SerializeField] public bool inDialog = false;
    [SerializeField] public Dictionary<string, ItemReference> equipedItems = new Dictionary<string, ItemReference>{
        {"helmet", null},
        {"ring1", null},
        {"ring2", null},
        {"weapon", null},
        {"shield", null},
        {"chest", null},
        {"pants", null},
        {"boots", null},
        {"belt", null},
        {"amulet", null},
        {"cloak", null}
    };
    [SerializeField] public Dictionary<string, float> stats = new Dictionary<string, float>{
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
    private Vector2 movement;

    [SerializeField] private GameObject inventorySlotsParent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        if(!inDialog)
            animator.SetFloat("Speed", movement.sqrMagnitude);
        else
            animator.SetFloat("Speed", 0);
    }
    private void FixedUpdate()
    {
        if(!inDialog)
            Move();
    }
    private void Move(){
        rb.MovePosition(rb.position + movement.normalized*speed*Time.fixedDeltaTime);
        // rb.velocity = new Vector2(horizontal, vertical).normalized*speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("DialogTrigger"))
        {
            headText.text = "Press Space to talk";
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("DialogTrigger"))
        {
            headText.text = "";
        }
    }

    private void UpdateStats(){
        foreach(KeyValuePair<string, ItemReference> item in equipedItems){
            if(item.Value != null){
                foreach(KeyValuePair<string, float> stat in item.Value.stats){
                    stats[stat.Key] += stat.Value;
                }
            }
        }
    }
    
    public void EquipItem(ItemReference item){
        if(item.type == "ring"){
            if(equipedItems["ring1"] == null){
                equipedItems["ring1"] = item;
            }
            else if(equipedItems["ring2"] == null){
                equipedItems["ring2"] = item;
            }
            else{
                UnequipItem(equipedItems["ring1"]);
                equipedItems["ring1"] = item;
            }
        }
        else{
            if(equipedItems[item.type] != null)
                UnequipItem(equipedItems[item.type]);
            equipedItems[item.type] = item;
        }
        UpdateStats();
    }   
    // remove item from player, then update the inventory
    public void UnequipItem(ItemReference item){
        if(item.type == "ring"){
            if(equipedItems["ring1"] == item){
                equipedItems["ring1"] = null;
            }
            else if(equipedItems["ring2"] == item){
                equipedItems["ring2"] = null;
            }
            else{
                equipedItems["ring1"] = null;
            }
        }
        else{
            equipedItems[item.type] = null;
        }
        foreach(ItemReference _item in inventorySlotsParent.GetComponentsInChildren<ItemReference>()){
            if(_item == item){
                _item.UpdateEquiped();
            }
        }
    }
    public void AddItem(Item item){
        GameObject _go = Resources.Load("prefabs/InventoryViewer") as GameObject;
        ItemReference itemRef = (Instantiate(_go, inventorySlotsParent.transform) as GameObject).GetComponent<ItemReference>();
        itemRef.SetValues(item);
    }

}