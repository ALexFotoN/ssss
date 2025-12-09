public class EventOfAnimationStrategy : AnimationStrategy
{
    public EventOfAnimationStrategy(CharacterAnimationPlayer animationPlayer) : base(animationPlayer)
    {
    }

    public override void Apply(AttackData data)
    {
        AnimationPlayer.EventCallback += OnComplted;
        base.Apply(data);
    }

    public override void Dispose()
    {
        AnimationPlayer.EventCallback -= OnComplted;
        base.Dispose();
    }

    private void OnComplted()
    {
        IsCompleted = true;
        AnimationPlayer.EventCallback -= OnComplted;
    }
}
