using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class RePlay : MonoBehaviour
{
    private VisualElement homeElement;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        homeElement = root.Q<VisualElement>("HomePlay");

        homeElement.style.display = DisplayStyle.Flex;
        Button RePlay = root.Q<Button>("RePlay");
        RePlay.RegisterCallback<ClickEvent>(Replaygame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Replaygame(ClickEvent cke)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
