using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimationPlayer: MonoBehaviour
{
    [field: SerializeField] public Animator Animator { get; private set; }

    public event Action EventCallback;

    private void Reset()
    {
        Animator = GetComponent<Animator>();
    }

    public void OnAnimationEvent(AnimationEvent animationEvent)
    {
        EventCallback?.Invoke();
    }
}
