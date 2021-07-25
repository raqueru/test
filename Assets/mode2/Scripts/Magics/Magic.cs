using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Magic
{
   public string Name;
   public int Level;
   public List<MagicElement> Element;
   public  List<MagicType>  Type;

   public int Mana;
   public string Description;

}

public enum MagicElement{
    Fire,Eletric,Dark,Plant
}
public enum MagicType{
    Defensive,Attack, Buff
}
