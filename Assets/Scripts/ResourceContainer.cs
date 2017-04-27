using System;
using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

/// <summary>
/// Container to hold all resource values. Is a singleton so is globally accessible by all scripts
/// </summary>

public class ResourceContainer : Singleton<ResourceContainer>
{
    public int Honor;

    public int Copper;
    public int Tin;
    public int Iron;
    public int Coal;
    public int Steel;
    public int Gold;
    public int Titanium;
    public int Diamond;
    public int Meteorite;

    public int Logs;
    public int OakLogs;
    public int WillowLogs;
    public int YewLogs;
    public int ElderLogs;

    public int Concrete;
    public int Bricks;

    public int Happiness;
    public int Culture;
    public int Science;

    private void Start()
    {
        Resource.LoadResources();
    }

    private void OnDestroy()
    {
        Resource.SaveResources();
    }
}

[Serializable]
public class Resource
{
    public int Honor;

    public int Copper;
    public int Tin;
    public int Iron;
    public int Coal;
    public int Steel;
    public int Gold;
    public int Titanium;
    public int Diamond;
    public int Meteorite;

    public int Logs;
    public int OakLogs;
    public int WillowLogs;
    public int YewLogs;
    public int ElderLogs;

    public int Concrete;
    public int Bricks;

    public int Happiness;
    public int Culture;
    public int Science;

    public Resource()
    {
        
    }

    public static void LoadResources()
    {
        Resource newInstance = SavingLoadingData.Instance.LoadDataFromFileAsJSON<Resource>(SavingLoadingData.Instance.resourceFilePath);

        ResourceContainer.Instance.Honor = newInstance.Honor;

        ResourceContainer.Instance.Copper = newInstance.Copper;
        ResourceContainer.Instance.Tin = newInstance.Tin;
        ResourceContainer.Instance.Iron = newInstance.Iron;
        ResourceContainer.Instance.Coal = newInstance.Coal;
        ResourceContainer.Instance.Steel = newInstance.Steel;
        ResourceContainer.Instance.Gold = newInstance.Gold;
        ResourceContainer.Instance.Titanium = newInstance.Titanium;
        ResourceContainer.Instance.Diamond = newInstance.Diamond;
        ResourceContainer.Instance.Meteorite = newInstance.Meteorite;

        ResourceContainer.Instance.Logs = newInstance.Logs;
        ResourceContainer.Instance.OakLogs = newInstance.OakLogs;
        ResourceContainer.Instance.WillowLogs = newInstance.WillowLogs;
        ResourceContainer.Instance.YewLogs = newInstance.YewLogs;
        ResourceContainer.Instance.ElderLogs = newInstance.ElderLogs;

        ResourceContainer.Instance.Concrete = newInstance.Concrete;
        ResourceContainer.Instance.Concrete = newInstance.Bricks;

        ResourceContainer.Instance.Happiness = newInstance.Happiness;
        ResourceContainer.Instance.Culture = newInstance.Culture;
        ResourceContainer.Instance.Science = newInstance.Science;
    }

    public static void SaveResources()
    {
        Resource newInstance = new Resource();

        newInstance.Honor = ResourceContainer.Instance.Honor;

        newInstance.Copper = ResourceContainer.Instance.Copper;
        newInstance.Tin = ResourceContainer.Instance.Tin;
        newInstance.Iron = ResourceContainer.Instance.Iron;
        newInstance.Coal = ResourceContainer.Instance.Coal;
        newInstance.Steel = ResourceContainer.Instance.Steel;
        newInstance.Gold = ResourceContainer.Instance.Gold;
        newInstance.Titanium = ResourceContainer.Instance.Titanium;
        newInstance.Diamond = ResourceContainer.Instance.Diamond;
        newInstance.Meteorite = ResourceContainer.Instance.Meteorite;

        newInstance.Logs = ResourceContainer.Instance.Logs;
        newInstance.OakLogs = ResourceContainer.Instance.OakLogs;
        newInstance.WillowLogs = ResourceContainer.Instance.WillowLogs;
        newInstance.YewLogs = ResourceContainer.Instance.YewLogs;
        newInstance.ElderLogs = ResourceContainer.Instance.ElderLogs;

        newInstance.Concrete = ResourceContainer.Instance.Concrete;
        newInstance.Bricks = ResourceContainer.Instance.Concrete;

        newInstance.Happiness = ResourceContainer.Instance.Happiness;
        newInstance.Culture = ResourceContainer.Instance.Culture;
        newInstance.Science = ResourceContainer.Instance.Science;

        SavingLoadingData.Instance.SaveDataToFileAsJSON(SavingLoadingData.Instance.resourceFilePath, newInstance);
    }
}