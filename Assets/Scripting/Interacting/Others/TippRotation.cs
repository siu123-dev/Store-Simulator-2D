using UnityEngine;

public class TippRotation : MonoBehaviour
{
    public Transform tippParent;
    void Update()
    {
        if(tippParent.eulerAngles.z == 0f)
        {
            return;
        }
        else if(tippParent.eulerAngles.z != 0f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
