using UnityEngine;

public class ChaseState : FishState
{
    public override void Enter()
    {
        Debug.Log($"{fish.gameObject.name} : Chase State");
    }

    public override void UpdateState()
    {
        if (fish == null)
            return;

        if (fish.trnPlayer == null || !fish.IsPlayerInRange())
        {
            fish.ChangeState(new IdleState());
        }
    }

    public override void FixedUpdateState()
    {
        if (fish != null && fish.trnPlayer != null)
            fish.Move(fish.trnPlayer.position);
    }

    public override void Exit()
    {
        fish.StopMove();
    }
}
