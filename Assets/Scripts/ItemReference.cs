using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemReference : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Image Icon;
    [SerializeField] public bool isEquiped;
    [SerializeField] public TMP_Text equipedText;
    [SerializeField] public string type;
    [SerializeField] public Dictionary<string, float> stats;
    public Item _Item {get; private set;}

    void Start()
    {
    }
    public void SetValues(Item item){

        _Item = item;
        Icon.sprite = item.icon;
        isEquiped = item.isEquiped;
        equipedText.text = item.isEquiped ? "E" : "";
        type = item.type;
        stats = item.stats;
    }
    public void UpdateEquiped(){
        isEquiped = !isEquiped;
        equipedText.text = isEquiped ? "E" : "";
    }
}
