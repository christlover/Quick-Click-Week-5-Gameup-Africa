using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{

    private Button button;

    private gameManager GameManager;

    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

        GameManager = GameObject.Find("Game Manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty() {
        Debug.Log(gameObject.name + " was Clicked");
        GameManager.StartGame(difficulty);
    }
}
