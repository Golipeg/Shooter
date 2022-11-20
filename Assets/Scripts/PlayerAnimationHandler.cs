using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
  [SerializeField] private Animator _animator;
  private static readonly int IsWalking = Animator.StringToHash("IsWalking");
  private static readonly int DieTrigger = Animator.StringToHash("DieTrigger");

  public void SetWalkMode(bool isWalking)
  {
    _animator.SetBool(IsWalking,isWalking);
  }

  public void PlayDieAnimation()
  {
    _animator.SetTrigger(DieTrigger);
  }
}
