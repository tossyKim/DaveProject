using UnityEngine;

public class FishAggressiveFSM : FishFSM
{
    [Header("Aggressive Fish")]
    public float aggressiveDetectionRange = 7f;
    public float chaseSpeed = 3f;

    protected override void Start()
    {
        detectionRange = aggressiveDetectionRange;
        speedMove = chaseSpeed;
        base.Start();
    }

    public override void OnPlayerDetected()
    {        
        ShowReactionSprite();
        ChangeState(new ChaseState());
    }
}
