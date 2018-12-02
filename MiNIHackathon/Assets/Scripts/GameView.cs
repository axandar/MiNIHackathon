using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameView : MonoBehaviour {

    public GameController GameController;
    public GameMenu GameMenu;

    public void StartClick(){
        HideMenu();
        GameController.StartGame();
    }

    public void ShowMenu(){
        GameMenu.Show();
    }

    public void HideMenu(){
        GameMenu.Hide();
    }
}
