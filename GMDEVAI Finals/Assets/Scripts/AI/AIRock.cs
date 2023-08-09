using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRock : NPCBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        var currentPath = NPC.GetComponent<ZombieAI>().path;
        
        var direction = currentPath.corners[currentPath.corners.Length - 1] - NPC.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, 
            Quaternion.LookRotation(direction),
            rotSpeed * Time.deltaTime);
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
