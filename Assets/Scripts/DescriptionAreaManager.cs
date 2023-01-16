using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DescriptionAreaManager : MonoBehaviour
{
    [SerializeField] public TMP_Text nameText;
    [SerializeField] public TMP_Text descriptionText;
    [SerializeField] public bool isShop = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!isShop){

            InventoryMouseSensitive.MouseOn += UpdateDescription;
            InventoryMouseSensitive.MouseOff += ResetInformaton;
        }
        else{
            ShopMouseSensitive.MouseOn += UpdateDescription;
            ShopMouseSensitive.MouseOff += ResetInformaton;
        }
        nameText.text = "";
        descriptionText.text = "";
        
    }

    private void OnDestroy()
    {
        if(!isShop){

            InventoryMouseSensitive.MouseOn -= UpdateDescription;
            InventoryMouseSensitive.MouseOff -= ResetInformaton;
        }
        else{
            ShopMouseSensitive.MouseOn -= UpdateDescription;
            ShopMouseSensitive.MouseOff -= ResetInformaton;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateDescription(string name, string description){
        nameText.text = name;
        descriptionText.text = description;
    }
    private void ResetInformaton(){
        nameText.text = "";
        descriptionText.text = "";
    }
}
