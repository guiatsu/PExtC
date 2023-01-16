using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText;
    [SerializeField] public float gold = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGoldText(gold);
    }
    public void SetGold(float gold)
    {
        this.gold = gold;
        UpdateGoldText(gold);
    }
    public float GetGold()
    {
        return gold;
    }
    void UpdateGoldText(float gold)
    {
        goldText.text = "Gold: " + Mathf.FloorToInt(gold).ToString();
    }
}
