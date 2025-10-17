using UnityEngine;
using UnityEngine.UI;
public class UiAtak : MonoBehaviour
{
    [SerializeField] private GameManager _gm;
    [SerializeField] private Image _image;




    private void Awake()
    {
        _gm.Smena += NewAtak;
    }

    public void NewAtak(int _tipe)
    {
        
        switch (_tipe)
        {
            case 0:
                _image.color = new Color(1f, 0f, 0f);
                break;
            case 1:
                _image.color = new Color(1f, 0f, 1f);
                break;
            case 2:
                _image.color = new Color(0f, 0f, 1f);
                break;
        }
    }
}
