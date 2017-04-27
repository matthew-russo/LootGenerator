using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMenu : MonoBehaviour
{
    private static GameObject _shop, _build, _craft, _dungeon, _gather;
    public static Dictionary<MenuState.menuState, GameObject> stateToObject;
    private GameObject _currentMenu;

    private bool _firstTimeThrough = false;

    private void Start()
    {
        _shop = transform.GetChild(0).gameObject;
        _build = transform.GetChild(1).gameObject;
        _craft = transform.GetChild(2).gameObject;
        _dungeon = transform.GetChild(3).gameObject;
        _gather = transform.GetChild(4).gameObject;

        stateToObject = new Dictionary<MenuState.menuState, GameObject>()
        {
            {MenuState.menuState.Shop, _shop},
            {MenuState.menuState.Build, _build },
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
            _build.SetActive(false);
            _craft.SetActive(false);
            _dungeon.SetActive(false);
            _gather.SetActive(false);

            _currentMenu = _build;
            SwitchScene(MenuState.menuState.Gather);

            _firstTimeThrough = true;
        }   
    }

    public void SwitchScene(MenuState.menuState stateToEnter)
    {
        _currentMenu.SetActive(false);
        _currentMenu = stateToObject[stateToEnter];
        _currentMenu.SetActive(true);
    }

}
