using System;

public abstract class AnimationStrategy : IDisposable
{
    protected readonly CharacterAnimationPlayer AnimationPlayer;

    public AnimationStrategy(CharacterAnimationPlayer animationPlayer)
    {
        AnimationPlayer = animationPlayer;
    }

    public virtual bool IsCompleted { get; protected set; } = true;

    public virtual void Apply(AttackData data)
    {
        AnimationPlayer.Animator.SetInteger("AttackType", data.AttackIndex);
        AnimationPlayer.Animator.SetTrigger(data.AttackParameterName);
        IsCompleted = false;
    }

    public virtual void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
