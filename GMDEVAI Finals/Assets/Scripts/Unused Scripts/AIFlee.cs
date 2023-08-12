using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFlee : NPCBaseFSM
{
    //NOTE: I have no idea if we need this
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var direction = NPC.transform.position - opponent.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, 
            Quaternion.LookRotation(direction),
            (rotSpeed * 10f) * Time.deltaTime); 
        NPC.transform.Translate(0, 0, Time.deltaTime * (speed * 3.0f)); 
    }
}
