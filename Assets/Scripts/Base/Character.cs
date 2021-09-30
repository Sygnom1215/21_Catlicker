using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Character
{
    public int charNumber;
    public long cPc
    {
        get
        {
            return Mathf.Max(charNumber * 3, 1);
        }
    }
    public int level;
    public long price;
}
