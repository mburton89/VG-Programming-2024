using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button onePlayerButton;
    public Button twoPlayerButton;
    public Button cpuPlayerButton;

    public PaddleAI p1AI;
    public PaddleAI p2AI;

    public GameObject menuContainer;

    // Start is called before the first frame update
    void Start()
    {
        onePlayerButton.onClick.AddListener(HandleOnePlayerButtonPressed);
        twoPlayerButton.onClick.AddListener(HandleTwoPlayerButtonPressed);
        cpuPlayerButton.onClick.AddListener(HandleCPUPlayerButtonPressed);
    }

    void HandleOnePlayerButtonPressed()
    { 
        p1AI.enabled = false;
        p2AI.enabled = true;
        menuContainer.SetActive(false);
        BallSpawner.Instance.SpawnBall();
    }

    void HandleTwoPlayerButtonPressed()
    {
        p1AI.enabled = false;
        p2AI.enabled = false;
        menuContainer.SetActive(false);
        BallSpawner.Instance.SpawnBall();
    }

    void HandleCPUPlayerButtonPressed()
    {
        p1AI.enabled = true;
        p2AI.enabled = true;
        menuContainer.SetActive(false);
        BallSpawner.Instance.SpawnBall();
    }
}
