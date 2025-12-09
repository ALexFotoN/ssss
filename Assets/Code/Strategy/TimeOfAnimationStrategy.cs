using UnityEngine;

public class TimeOfAnimationStrategy : AnimationStrategy
{
    private float _competedTime;

    public TimeOfAnimationStrategy(CharacterAnimationPlayer animationPlayer) : base(animationPlayer) { }

    public override bool IsCompleted { get => _competedTime <= Time.time; }

    public override void Apply(AttackData data)
    {
        _competedTime = Time.time + data.Animation.length;
        base.Apply(data);
    }
}
