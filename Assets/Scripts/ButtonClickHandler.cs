using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

class ButtonClickHandler : MonoBehaviour
{
    Program program;

    void Awake()
    {
        program = FindObjectOfType<Program>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ClickEvent);
    }

    void ClickEvent()
    {
        GameObject.Find("SelectSound").GetComponent<AudioSource>().Play();

        var clickedHider = this.gameObject;
        clickedHider.SetActive(false);
        var clickedObject = clickedHider.transform.parent.gameObject;

        program.clickedObject = clickedObject;
        program.clickedObjects.Add(clickedObject);
    }
}
