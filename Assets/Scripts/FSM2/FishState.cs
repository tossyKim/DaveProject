public abstract class FishState
{
    protected FishFSM fish;

    public virtual void Initialize(FishFSM fish)
    {
        this.fish = fish;
    }

    public virtual void Enter() { }
    public virtual void UpdateState() { }
    public virtual void FixedUpdateState() { }
    public virtual void Exit() { }
}
