using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMenu : MonoBehaviour
{
    private static GameObject _shop, _refinery, _craft, _dungeon, _gather;
    public static Dictionary<MenuState.menuState, GameObject> stateToObject;
    private GameObject _currentMenu;

    public GameObject HonorText;

    private bool _firstTimeThrough = false;

    private void Start()
    {
        _shop = transform.GetChild(0).gameObject;
        _refinery = transform.GetChild(1).gameObject;
        _craft = transform.GetChild(2).gameObject;
        _dungeon = transform.GetChild(3).gameObject;
        _gather = transform.GetChild(4).gameObject;

        stateToObject = new Dictionary<MenuState.menuState, GameObject>()
        {
            {MenuState.menuState.Shop, _shop},
            {MenuState.menuState.Build, _refinery },
            {MenuState.menuState.Craft, _craft },
            {MenuState.menuState.Dungeon, _dungeon },
            {MenuState.menuState.Gather, _gather },
        };
    }

    private void Update()
    {
        if (!_firstTimeThrough)
        {
            _shop.SetActive(false);
            _refinery.SetActive(false);
            _craft.SetActive(false);
            _dungeon.SetActive(false);
            _gather.SetActive(false);

            _currentMenu = _gather;
            SwitchScene(MenuState.menuState.Gather);

            _firstTimeThrough = true;
        }
        HonorText.SetActive(_gather.activeInHierarchy);
    }

    public void SwitchScene(MenuState.menuState stateToEnter)
    {
        _currentMenu.SetActive(false);
        _currentMenu = stateToObject[stateToEnter];
        _currentMenu.SetActive(true);
    }

}
