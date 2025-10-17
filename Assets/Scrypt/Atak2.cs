using UnityEngine;

public class Atak2 : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _delay;
   
    private void Awake()
    {
        Invoke(nameof(StartBullet),_delay);
        _anim.SetBool("Atak2", true);
    }

    private void StartBullet()
    {
        Instantiate(_bullet, transform.position, transform.rotation);
        Invoke(nameof(StartBullet), _delay);
    }
}
