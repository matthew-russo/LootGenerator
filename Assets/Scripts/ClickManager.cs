using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

/// <summary>
/// Class that holds functions for clicks and allocating the proper resources.
/// </summary>

public class ClickManager : MonoBehaviour
{
    public enum ResourceType
    {
        Honor,
        Wood,
        Iron,
        Gold,
    };

    public ResourceType CurrentResourceType;
    public float multiple = 1f;

    public void IncrementResource()
    {
        ResourceContainer.Instance.Honor += Mathf.RoundToInt(1 * multiple);
    }
}
