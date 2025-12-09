using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackData", menuName = "CreateNewattackData")]
public class AttackData : ScriptableObject
{
    [field: SerializeField] public AnimationClip Animation { get; private set; }
    [field: SerializeField] public string AttackParameterName { get; private set; }
    [field: SerializeField] public int AttackIndex { get; private set; }    
}
