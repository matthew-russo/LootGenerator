using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

public class MenuState : Singleton<MenuState> {
    public enum menuState
    {
        Shop,
        Build,
        Craft,
        Dungeon,
        Gather,
    }

    public menuState currentmenuState;
    private DisplayMenu _displayMenuScript;

    public void Awake()
    {
        currentmenuState = menuState.Gather;
    }

    public void Start()
    {
        _displayMenuScript = FindObjectOfType<DisplayMenu>();
    }

    public void setState(menuState stateToChangeTo)
    {
        currentmenuState = stateToChangeTo;
        _displayMenuScript.SwitchScene(currentmenuState);
    }

    public void ClickedShop()
    {
        setState(menuState.Shop);
        
        // Set Shop to active
        //
    }

    public void ClickedBuild()
    {
        //setState(menuState.Build);

        // Set Build to active
        //
    }

    public void ClickedCraft()
    {
        setState(menuState.Craft);

        // Set Craft to active
        //
    }

    public void ClickedDungeon()
    {
        //setState(menuState.Dungeon);

        // Set Dungeon to active
        //
    }

    public void ClickedGather()
    {
        setState(menuState.Gather);

        // Set Gather to active
        //
    }

}
