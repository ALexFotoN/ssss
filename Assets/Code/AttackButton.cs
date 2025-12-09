using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AttackButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _seletedColor;
    private Color _defaultColor;

    [field: SerializeField] public Button Button { get; private set; }
    [field: SerializeField] public AttackData Data { get; private set; }

    private void Reset()
    {
        Button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    private void Awake()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = Data.Animation.name;        
        _defaultColor = _image.color;
    }

    public void Select()
    {
        _image.color = _seletedColor;
    }

    public void UnSelect()
    {
        _image.color = _defaultColor;
    }
}
