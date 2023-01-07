
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private bool _shouldLockCursor;

    [SerializeField]
    private EnemyManager _enemyManager;

    [SerializeField] private EnemyCounterUI _enemyCounterUI;

    [SerializeField] private int _enemiesQuantity;

    [SerializeField] private Player _player;
    private void Start()
    {
        _enemyManager.Initialize(_player.transform,_enemiesQuantity);
        _enemyCounterUI.Initialize(_enemiesQuantity);
        if (_shouldLockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }
}
