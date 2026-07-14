using UnityEngine;

public class SettManagers : MonoBehaviour
{
    public CurrentMode currentMode;

    void Start()
    {
        currentMode = CurrentMode.Gameplay;
    }
}
