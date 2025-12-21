using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    protected bool IsCanAttack { get; set; } = true;

    public void Attack()
    {
        if (!IsCanAttack) return;

        PlayAttack();
        ExecuteAttack();
        CompleteAttack();
    }

    protected virtual void PlayAttack()
    {
        _animator.SetTrigger("Attack");
    }

    protected virtual void ExecuteAttack() 
    {
        print($"{name} - Attack Execute");
    }

    protected virtual void CompleteAttack() 
    {
        print($"{name} - Attack Completed");
    }
}
