using UnityEngine;

public class EnterDifferentModes : MonoBehaviour
{
    private SettManagers setts;

    private void Start()
    {
        setts = FindAnyObjectByType<SettManagers>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B) && setts.currentMode != CurrentMode.Build)
        {
            setts.currentMode = CurrentMode.Build;
        }
        else if (Input.GetKeyUp(KeyCode.B) && setts.currentMode == CurrentMode.Build)
        {
            setts.currentMode = CurrentMode.Gameplay;
        }
    }
}
