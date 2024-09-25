using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton; //WIP
    public TextMeshProUGUI title;

    public GameObject menuContainer;
    
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(HandleStartButtonPressed);
    }

    void HandleStartButtonPressed()
    {
        menuContainer.SetActive(false);
    }

}
