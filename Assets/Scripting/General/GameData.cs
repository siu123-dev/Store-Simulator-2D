using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public float money = 100f;

    public PlayerData playerData;
    public List<PackageSaveData> packages = new();
    public List<ShelfSaveData> shelfs = new();
}
