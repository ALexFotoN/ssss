using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
   
    private void Update()
    {
        transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
    }

 

}
