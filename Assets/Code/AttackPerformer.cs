using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AttackPerformer : MonoBehaviour
{
    [SerializeField] private CharacterAnimationPlayer _characterAnimationPlayer;
    [SerializeField] private AttackButton[] _buttons;
    [SerializeField] private TMP_Dropdown _completeDropdow;
    [SerializeField] private Transform _enemyPoint;
    private AnimationStrategy _currentStrategy;
    private AttackButton _selectedButton;
    [SerializeField] private CompleteType _currentCompleteType;

    private void Start()
    {
        _completeDropdow.options.Clear();
        _completeDropdow.options.Add(new(CompleteType.UseTime.ToString()));
        _completeDropdow.options.Add(new(CompleteType.UseEvent.ToString()));
        _completeDropdow.onValueChanged.AddListener(ChangeCompleteType);
        ChangeCompleteType(0);

        for (int i = 0; i < _buttons.Length; i++)
        {
            var button = _buttons[i];
            button.Button.onClick.AddListener(() => SelectedAttack(button));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ExecuteAttack();

            if(EnemyService.Instance.CurrentEnemy != null)
            {
                EnemyService.Instance.CurrentEnemy.Attack();
            }
        }
    }

    private void SelectedAttack(AttackButton button)
    {
        if (_currentStrategy != null && !_currentStrategy.IsCompleted) return;

        if(_selectedButton != null)
        {
            _selectedButton.UnSelect();
        }

        _selectedButton = button;
        _selectedButton.Select();

        EnemyService.Instance.ShowEnemy(button.LinkedEnemy, _enemyPoint.position);
    }
    private void ChangeCompleteType(int value)
    {
        if (_currentStrategy != null && !_currentStrategy.IsCompleted) return;

        _currentCompleteType = (CompleteType)value;

        if(_currentStrategy != null )
        {
            _currentStrategy.Dispose();
        }

        switch (_currentCompleteType)
        {
            case CompleteType.UseTime:
                _currentStrategy = new TimeOfAnimationStrategy(_characterAnimationPlayer);
                break;
            case CompleteType.UseEvent:
                _currentStrategy = new EventOfAnimationStrategy(_characterAnimationPlayer);
                break;
        }
    }

    private void ExecuteAttack()
    {
        if (_selectedButton == null) return;
        if (_currentStrategy != null && !_currentStrategy.IsCompleted) return;
        if(_selectedButton != null && _selectedButton.Data == null)
        {
            Debug.LogError("Not set data in button");
            return;
        }

        _currentStrategy.Apply(_selectedButton.Data);
    }
}

public enum CompleteType
{
    UseTime,
    UseEvent
}
