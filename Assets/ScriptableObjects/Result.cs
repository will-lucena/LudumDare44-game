using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Result", fileName = "lastResult")]
public class Result : ScriptableObject
{
    public int moneySelections;
    public int socialSelections;
    public int knowledgeSelections;
    public int healthSelections;
}