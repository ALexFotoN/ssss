using UnityEngine;
public class AtakPlayer : MonoBehaviour
{
    [SerializeField] private Animator _anim;


    public GameManager _gm;

    public int TipeAtak;

    private void Start()
    {
        _gm.Smena += NewAtak;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Atak();
        }
    }

    private void NewAtak(int index)
    {
        TipeAtak = index;
    }
    public void Atak()
    {
        switch (TipeAtak)
        {
            case 0:
                _anim.SetBool("Atak1", true);
                Invoke(nameof(AtakDown), 0.1f);
                break;
            case 1:
                _anim.SetBool("Atak2", true);
                Invoke(nameof(AtakDown), 0.1f);
                break;
            case 2:
                _anim.SetBool("Atak3", true);
                Invoke(nameof(AtakDown),0.1f);
                break;
        }
    }

    private void AtakDown()
    {
        _anim.SetBool("Atak1", false);
        _anim.SetBool("Atak2", false);
        _anim.SetBool("Atak3", false);
    }
}
