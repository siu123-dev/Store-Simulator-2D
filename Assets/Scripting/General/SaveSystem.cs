using UnityEngine;

public class SaveSystem : MonoBehaviour //SaveSystem
{
    public static SaveSystem Instance;
    public GameData Data;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string jsonGD = JsonUtility.ToJson(Data);
        PlayerPrefs.SetString("GameSave", jsonGD);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("GameSave"))
        {
            string json = PlayerPrefs.GetString("GameSave");
            Data = JsonUtility.FromJson<GameData>(json);
        }
        else
        {
            Data = new GameData();
        }
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteKey("GameSave"); // wichtig!
        Data = new GameData();

        Save();
        Debug.Log("Save zur�ckgesetzt");
    }

    private void Update()
    {
        // Debug-Reset (optional)
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.P))
        {
            ResetData();
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            Data.money += 5f;
            Save();
        }
    }
}