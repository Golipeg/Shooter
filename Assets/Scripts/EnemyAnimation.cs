using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _enemyAnimator;
    private static readonly int DieTrigger = Animator.StringToHash("DieTrigger");
    public  void PlayAnimationDying()
    {
        _enemyAnimator.SetTrigger(DieTrigger);
    }
    
    
}