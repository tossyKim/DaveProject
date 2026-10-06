using UnityEngine;

public class fishEscapeFSM : FishFSM
{
    [Header("Escape Fish")]
    public float escapeDetectionRange = 6f;
    public float escapeSpeed = 4f;

    protected override void Start()
    {
        detectionRange = escapeDetectionRange;
        speedMove = escapeSpeed;
        base.Start();
    }

    public override void OnPlayerDetected()
    {        
        ShowReactionSprite();
        ChangeState(new EscapeState());
    }
}
