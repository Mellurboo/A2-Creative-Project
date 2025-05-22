using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Objectives : MonoBehaviour {
    public CS_Objective[] objectives;
    
    /// <summary>
    /// will check if the output collected completes any objective, if it does
    /// and the matched objective isn't already complete it will market it as
    /// complete and return true
    /// </summary>
    /// <param name="queryItem">output item to query</param>
    /// <returns>true if an objective was completed, false if it fell out the loop</returns>
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
