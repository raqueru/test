using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public GameObject friendsScreen;
    public GameObject GrimoireScreen;

    public static Achievements instance;


    private void Awake()
    {
        instance = this;
        OpenAchievements();
    }

    public void ShowFriends()
    {
        this.gameObject.SetActive(false);
        friendsScreen.SetActive(true);
    }

    public void ShowGrimoire()
    {
        this.gameObject.SetActive(false);
        Grimoire.instance.UpdateGrimoire();
        GrimoireScreen.SetActive(true);
    }
    public void OpenAchievements()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}
