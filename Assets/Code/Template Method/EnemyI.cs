public class EnemyI : Enemy
{
    private bool _isCanAttack;

    private void OnEnable()
    {
        IsCanAttack = true;
        Attack();
    }

    protected override void CompleteAttack()
    {
        IsCanAttack = false;
    }
}
