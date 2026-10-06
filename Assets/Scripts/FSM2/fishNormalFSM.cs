using UnityEngine;

public class fishNormalFSM : FishFSM
{
    [Header("Normal Fish")]
    public float normalDetectionRange = 4f;

    protected override void Start()
    {
        detectionRange = normalDetectionRange;
        base.Start();
    }

    public override void OnPlayerDetected()
    {        
        ShowReactionSprite();
    }
}