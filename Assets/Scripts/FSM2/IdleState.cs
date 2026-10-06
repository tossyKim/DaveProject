using UnityEngine;

public class IdleState : FishState
{
    private float stateTimer;
    private float moveTimer;
    private Vector2 randomDirection;
    private bool reactedToCurrentDetection;

    private const float MIN_STATE_TIME = 2f;
    private const float MAX_STATE_TIME = 5f;
    private const float MIN_MOVE_TIME = 1f;
    private const float MAX_MOVE_TIME = 3f;

    public override void Enter()
    {
        stateTimer = Random.Range(MIN_STATE_TIME, MAX_STATE_TIME);
        reactedToCurrentDetection = false;
        SetRandomDirection();
    }

    public override void UpdateState()
    {
        if (fish == null)
            return;

        stateTimer -= Time.deltaTime;
        moveTimer -= Time.deltaTime;

        bool playerInRange = fish.IsPlayerInRange();

        if (playerInRange && !reactedToCurrentDetection)
        {
            reactedToCurrentDetection = true;
            fish.OnPlayerDetected();
            return;
        }

        if (!playerInRange)
            reactedToCurrentDetection = false;

        if (moveTimer <= 0f)
            SetRandomDirection();

        if (stateTimer <= 0f)
        {
            stateTimer = Random.Range(MIN_STATE_TIME, MAX_STATE_TIME);
            SetRandomDirection();
        }
    }

    public override void FixedUpdateState()
    {
        if (fish != null)
            fish.MoveDirection(randomDirection);
    }

    public override void Exit()
    {
        fish.StopMove();
    }

    private void SetRandomDirection()
    {
        randomDirection = Random.insideUnitCircle.normalized;
        moveTimer = Random.Range(MIN_MOVE_TIME, MAX_MOVE_TIME);
    }
}
