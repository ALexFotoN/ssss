using UnityEngine;

public class Atak1 : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private void Awake()
    {
        _anim.SetBool("Atak1", true);
        Invoke(nameof(DontAtak), 0.2f);
    }

    private void DontAtak()
    {
        _anim.SetBool("Atak1", false);
        _anim.SetBool("Atak2", false);
        _anim.SetBool("Atak3", false);
    }    
}
