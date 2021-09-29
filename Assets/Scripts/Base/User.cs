using System.Collections.Generic;

[System.Serializable]
public class User
{
    public string userName;
    public int charNum;
    public long churu;
    public List<Item> itemList = new List<Item>();
    public List<Character> charList = new List<Character>();
}