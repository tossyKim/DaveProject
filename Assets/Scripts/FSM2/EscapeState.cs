using UnityEngine;

public class EscapeState : FishState
{
    public override void Enter()
    {
        Debug.Log($"{fish.gameObject.name} : Escape State");
    }

    public override void UpdateState()
    {
        if (fish == null)
            return;

        if (fish.trnPlayer == null || !fish.IsPlayerInRange())
            fish.ChangeState(new IdleState());
    }

    public override void FixedUpdateState()
    {
        if (fish == null || fish.trnPlayer == null)
            return;

        Vector2 escapeDirection = fish.transform.position - fish.trnPlayer.position;
        fish.MoveDirection(escapeDirection);
    }

    public override void Exit()
    {
        fish.StopMove();
    }
}
