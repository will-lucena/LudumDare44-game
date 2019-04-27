﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Props", fileName = "props")]
public class GameProps : ScriptableObject
{
    public int numberOfTurns;
    public int maxStatusValue;
}
