using UnityEngine;

public class PositionHandler : MonoBehaviour
{
    public Transform plTransform;

    public GameObject packagePrefab;

    void Start()
    {
        plTransform.transform.position = SaveSystem.Instance.Data.playerData.playerPosition;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.O))
        {
            SaveSystem.Instance.Data.playerData.playerPosition = plTransform.transform.position;
            SaveSystem.Instance.Save();
        }
    }
}
