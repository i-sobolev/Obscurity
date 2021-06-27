using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class PlayerData
{
    public static PlayerViewModel Values;
}

[System.Serializable]
public class PlayerViewModel
{
    public int id;
    public string name;
    public int worldId;
}