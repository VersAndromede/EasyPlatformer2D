using System.Collections;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _extraJumpTime = 0.04f;

    private Coroutine _deactivateJumpJob;

    public bool IsGround { get; private set; }
    public bool IsJumpChanceUsed { get; private set; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
        {
            IsGround = true;
            IsJumpChanceUsed = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Ground>(out Ground ground))
        {
            if (_deactivateJumpJob != null)
                StopCoroutine(_deactivateJumpJob);

            _deactivateJumpJob = StartCoroutine(DeactivateJump());
        }
    }

    public void DeactivateJumpPremature()
    {
        if (_deactivateJumpJob != null)
            StopCoroutine(_deactivateJumpJob);

        IsGround = false;
        IsJumpChanceUsed = true;
    }

    private IEnumerator DeactivateJump()
    {
        yield return new WaitForSeconds(_extraJumpTime);
        IsGround = false;
        IsJumpChanceUsed = true;
    }
}
