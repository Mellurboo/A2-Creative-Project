using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Objectives : MonoBehaviour {
    public CS_Objective[] objectives;

    public void queryObjectives(SO_Item queryItem) {
        foreach (CS_Objective obj in objectives) {
            if (obj.targetItem == queryItem && !obj.isComplete) {
                obj.CompleteObjective();
            }
        }
    }
}
