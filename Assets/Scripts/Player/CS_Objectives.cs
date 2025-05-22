using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Objectives : MonoBehaviour {
    public CS_Objective[] objectives;

    public bool queryObjectives(SO_Item queryItem) {
        foreach (CS_Objective obj in objectives) {
            if (obj.targetItem == queryItem && !obj.isComplete) {
                obj.CompleteObjective();
                return true;
            }
        }
        return false;
    }
}
