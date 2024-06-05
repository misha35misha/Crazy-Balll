using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private LevelFrame[] _levels;

    public void LevelsStatus()
    {
        for (int i = 0; i < _levels.Length; i++)
        {
            if (Global.Instance.SaveData.UnlockLevel < i)
            {
                _levels[i].SetLock(true);
            }
            else
            {
                _levels[i].SetLock(false);
                _levels[i].SetStars(Global.Instance.SaveData.Stars[i]);
            }
            
        }
    }
}
