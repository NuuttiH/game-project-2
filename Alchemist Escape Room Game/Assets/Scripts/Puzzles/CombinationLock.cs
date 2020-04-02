﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Puzzle (Combination Lock)", menuName = "Puzzle (Combination Lock)")]
public class CombinationLock : ScriptableObject{
    [TextArea(10,15)]
    public string puzzleText;
    public char[] correctSolution = new char[3];

    public Item rewardItem;
    public int customEventId;

    public Dialogue firstFailDialogue;
    public Dialogue firstSuccessDialogue;
    public Dialogue correctSolutionDialogue;
}
