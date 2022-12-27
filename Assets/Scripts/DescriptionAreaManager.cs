using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DescriptionAreaManager : MonoBehaviour
{
    [SerializeField] public TMP_Text nameText;
    [SerializeField] public TMP_Text descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        MouseSensitive.MouseOn += UpdateDescription;
        MouseSensitive.MouseOff += ResetInformaton;
        nameText.text = "";
        descriptionText.text = "";
        
    }

    private void OnDestroy()
    {
        MouseSensitive.MouseOn -= UpdateDescription;
        MouseSensitive.MouseOff -= ResetInformaton;
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
