using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    Button RetryButton;

    private void Start()
    {
        RetryButton = GetComponent<Button>();
        RetryButton.onClick.AddListener(HandleButton);
    }

    public void HandleButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
