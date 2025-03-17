using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    private VisualElement homeElement;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        homeElement = root.Q<VisualElement>("HomePlay");

        homeElement.style.display = DisplayStyle.Flex;
        Button RePlay = root.Q<Button>("Play");
        RePlay.RegisterCallback<ClickEvent>(playgame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void playgame(ClickEvent cke)
    {
        SceneManager.LoadScene("Assign edit");
        Time.timeScale = 1;
    }
}
