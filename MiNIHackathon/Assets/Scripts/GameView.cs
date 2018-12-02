using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameView : MonoBehaviour {

    public GameController GameController;
    public GameMenu GameMenu;
    
    private void Start(){
        if (!GameController){
            Debug.LogError("!gameController");
        }
        
        if (!GameMenu){
            Debug.LogError("!gameMenu");
        }
    }

    public void StartClick(){
        Debug.Log("GameView::StartClick");

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
