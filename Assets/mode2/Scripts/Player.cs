using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string charName;
    public int SpellsSlots=9;
    [SerializeField]
    public List <Magic> lv1Magics = new List<Magic>();
    [SerializeField]
    public List <Magic> lv2Magics = new List<Magic>();
    [SerializeField]
    public List <Magic> lv3Magics = new List<Magic>();
    public static Player instance;

    private void Awake() {
        instance=this;
    }
    private void Update() {
        if(Input.GetKeyDown("return")){
            if(Grimoire.instance.gameObject.activeSelf){
                Grimoire.instance.OpenGrimoire();
            }
            Achievements.instance.OpenAchievements();

        }
    }


}
