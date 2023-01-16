using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ShopMouseSensitive : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private ItemReference _itemReference;
    private Player _player;
    private GameController _gameController;
    public static event System.Action<string,string> MouseOn;
    public static event System.Action MouseOff;
    public static event System.Action MouseClick;
    // Start is called before the first frame update
    void Start()
    {
     _itemReference = GetComponent<ItemReference>();
     _player = FindObjectOfType<Player>().GetComponent<Player>();
    _gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
     ChangeColor(Color.gray);

    }

    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData){
        if(_gameController.GetGold() >= _itemReference.value){
            _gameController.SetGold(_gameController.GetGold() - _itemReference.value);
            _player.AddItem(_itemReference._Item);
        }
    }
    public void OnPointerEnter(PointerEventData eventData){
        ChangeColor(Color.white);
        MouseOn?.Invoke(_itemReference._Item._name, "Value: "+Mathf.FloorToInt(_itemReference.value).ToString()+" Gold\n" + _itemReference._Item.description);
    }
    public void OnPointerExit(PointerEventData eventData){
        ChangeColor(Color.gray);
        MouseOff?.Invoke();
    }
    private void ChangeColor(Color color){
        _itemReference.Icon.color = color;
    }
}
