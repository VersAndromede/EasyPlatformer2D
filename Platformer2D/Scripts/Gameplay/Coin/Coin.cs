using UnityEngine.Events;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private UnityEvent _collected;

    public void Collect()
    {
        _collected.Invoke();
    }    
}
