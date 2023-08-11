using UnityEngine;

public class AIChase : NPCBaseFSM
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPCAgent.ResetPath();
        NPCAgent.speed = speed;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var direction = opponent.transform.position - NPC.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, 
                                 Quaternion.LookRotation(direction),
                                 rotSpeed * Time.deltaTime); 
        
        //NPC.transform.Translate(0, 0, Time.deltaTime * speed);
        NPCAgent.SetDestination(opponent.transform.position);
        
        //========================
        opponent.GetComponent<PlayerController>().beingChased = true;
        //========================
    }
}
