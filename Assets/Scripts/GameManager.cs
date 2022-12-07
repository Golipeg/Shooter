
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _shouldLockCursor;
    private void Start()
    {
        if (_shouldLockCursor)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        
    }
}
