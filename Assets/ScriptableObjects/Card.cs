using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card", fileName = "props")]
public class Card : ScriptableObject
{
    public string description;
    public int buffValue;
    public int nerfValue;
    public Status buffType;
    public Status nerfType;
}
