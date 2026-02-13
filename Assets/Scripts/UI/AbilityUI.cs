using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class AbilityUI : MonoBehaviour, IPointerClickHandler
{
    private PlayerController player;
    private EnemySpawner enemySpawner;
    private GameObject abilityUI;
    public TextMeshProUGUI playerDamageText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        abilityUI = GameObject.Find("Canvas");
        enemySpawner = GameObject.Find("SpawnEnemy").GetComponent<EnemySpawner>();
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
        ApplyAbilityEffect(ability);
        RoundEndAbilityUI();
    }
    public void RoundEndAbilityUI()
    {
        // Logic for displaying ability UI at the end of a round
        Debug.Log("Displaying Ability UI at Round End");
        abilityUI.SetActive(false);
        enemySpawner.StartNextWave();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnAbilityCardSelected();
    }

    public void ApplyAbilityEffect(string ability)
    {
        // Logic to apply the effect of the selected ability to the player
        Debug.Log("Applying Ability Effect to Player");

        if (ability == "Add Weapon")
        {
            Debug.Log("Player gains a new weapon!");
        }
        if (ability == "Damage +5%")
        {
            player.playerDamage = Mathf.CeilToInt(player.playerDamage * 1.05f);
        }
        if (ability == "Fire Rate +5%")
        {
            player.timeBetweenShots -= player.timeBetweenShots * 0.05f;
        }
    }
}
