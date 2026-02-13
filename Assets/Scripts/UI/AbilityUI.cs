using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class AbilityUI : MonoBehaviour, IPointerClickHandler
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // player = GameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnAbilityCardSelected()
    {
        // Logic for when an ability card is selected
        // Debug.Log(gameObject);
        Transform infoText = transform.GetChild(1);
        string ability = infoText.GetComponent<TextMeshProUGUI>().text;
        Debug.Log(ability);
        RoundEndAbilityUI();
    }
    public void RoundEndAbilityUI()
    {
        // Logic for displaying ability UI at the end of a round
        Debug.Log("Displaying Ability UI at Round End");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnAbilityCardSelected();
    }
}
