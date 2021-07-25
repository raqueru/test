using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    public MagicElement element;
    public int MagicsTeached = 0;



    private void OnTriggerStay2D(Collider2D other)
    {


        if (other.gameObject.tag == "Player" && Input.GetKeyDown("z"))
        {
            TeachMagic(element, MagicsTeached + 1);
            MagicsTeached++;
        }
          if (other.gameObject.tag == "Player" && Input.GetKeyDown("x"))
        {
            MixMagics(Player.instance.lv1Magics[0],Player.instance.lv1Magics[1], 1);
         }
    }

    public void TeachMagic(MagicElement element, int magicLevel)
    {
        switch (magicLevel)
        {
            case (1):
                if (Player.instance.SpellsSlots >= 1)
                {

                    Player.instance.lv1Magics.Add(Balance.Magics.FindMagicByElementAndLevel(element, magicLevel));
                    Debug.Log(Player.instance.lv1Magics.Count);
                    Player.instance.SpellsSlots -= 1;
                }
                break;
            case (2):
                if (Player.instance.SpellsSlots >= 2)
                {
                    Player.instance.lv2Magics.Add(Balance.Magics.FindMagicByElementAndLevel(element, magicLevel));
                    Player.instance.SpellsSlots -= 2;
                }
                break;
            case (3):
                if (Player.instance.SpellsSlots >= 3)
                {
                    Player.instance.lv3Magics.Add(Balance.Magics.FindMagicByElementAndLevel(element, magicLevel));
                    Player.instance.SpellsSlots -= 3;
                }
                break;
        }

    }
    public void MixMagics(Magic magic1, Magic magic2,int magicLevel)
    {
        if (magic1.Element.Count <= 2 || magic2.Element.Count <= 2)
        {
        switch (magicLevel){
         case (1):


            Magic NewMagic= Balance.Magics.FindMixedMagicByElementAndLevel(magic1.Element[0],magic2.Element[0],magicLevel);
            if(NewMagic==null){
               NewMagic= Balance.Magics.FindMixedMagicByElementAndLevel(magic2.Element[0],magic1.Element[0],magicLevel);
            }
            Player.instance.lv1Magics.Remove(magic1);
            Player.instance.lv1Magics.Remove(magic2);
            Player.instance.lv1Magics.Add(NewMagic);
            Debug.Log("s");

            break;
            case (2):

            Magic NewMagic2= Balance.Magics.FindMixedMagicByElementAndLevel(magic1.Element[0],magic1.Element[1],magicLevel);
            Player.instance.lv2Magics.Remove(magic1);
            Player.instance.lv2Magics.Remove(magic2);
            Player.instance.lv2Magics.Add(NewMagic2);

            break;
            case (3):

            Magic NewMagic3= Balance.Magics.FindMixedMagicByElementAndLevel(magic1.Element[0],magic1.Element[1],magicLevel);
            Player.instance.lv3Magics.Remove(magic1);
            Player.instance.lv3Magics.Remove(magic2);
            Player.instance.lv3Magics.Add(NewMagic3);

            break;
        }

    }
}

}
