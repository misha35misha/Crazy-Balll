using UnityEngine;

public class LevelsUpdate : MonoBehaviour
{
    [SerializeField] private Menu _menu;

    private void OnEnable()
    {
        _menu.LevelsStatus();
    }
}
