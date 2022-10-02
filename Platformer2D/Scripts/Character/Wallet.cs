using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _balance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _balance++;
            coin.Collect();
            Debug.Log(_balance);
        }
    }
}
