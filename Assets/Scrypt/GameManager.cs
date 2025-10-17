using UnityEngine;
using System;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int Tipe;

    [SerializeField] private GameObject[] _units;
    [SerializeField] private Transform _pos;
    [SerializeField] private int _atakMax;

    private GameObject _object;

    public Action<int> Smena;



    private void Start()
    {
        _object = Instantiate(_units[Tipe], _pos.transform.position, _pos.transform.rotation);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NewAtak();
            Smena.Invoke(Tipe); 
        }
    }

    public void NewAtak()
    {
        Tipe++;

        Destroy(_object);
        if (Tipe > _atakMax)
        {
            Tipe = 0;
        }
        _object = Instantiate(_units[Tipe], _pos.transform.position, _pos.transform.rotation);
        if (_object.GetComponent<AtakPlayer>())
        {
            _object.GetComponent<AtakPlayer>()._gm = GetComponent<GameManager>();
            _object.GetComponent<AtakPlayer>().TipeAtak = Tipe;
        }
        
    }
}
