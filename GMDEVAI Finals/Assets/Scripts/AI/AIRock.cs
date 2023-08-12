using UnityEngine;

public class AIRock : NPCBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPCAgent.speed = speed;
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        NPC.GetComponent<ZombieAI>().MoveToTarget();

        if (NPC.GetComponent<ZombieAI>().agent.remainingDistance < 1)
        {
            NPC.GetComponent<ZombieAI>().ResetTarget();
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
    }
}
