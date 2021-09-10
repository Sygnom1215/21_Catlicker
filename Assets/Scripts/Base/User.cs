using System.Collections.Generic;

[System.Serializable]
public class User
{
    public string userName;
    public long churu;
    public List<Item> itemList = new List<Item>();
}