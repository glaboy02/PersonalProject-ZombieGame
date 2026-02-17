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
    public static int weaponCount = 1;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        abilityUI = GameObject.Find("Canvas");
        enemySpawner = GameObject.Find("SpawnEnemy").GetComponent<EnemySpawner>();
    }

    void Update()
    {
        playerDamageText.text = "Damage: " + player.playerDamage.ToString() + "\n" + "Weapons: " + weaponCount.ToString();
    }

    public void OnAbilityCardSelected()
    {
        Transform infoText = transform.GetChild(1);
        string ability = infoText.GetComponent<TextMeshProUGUI>().text;
        ApplyAbilityEffect(ability);
        RoundEndAbilityUI();
    }
    public void RoundEndAbilityUI()
    {
        abilityUI.SetActive(false);
        enemySpawner.StartNextWave();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnAbilityCardSelected();
    }

    public bool ApplyAbilityEffect(string ability)
    {
        if (ability == "Add Weapon")
        {
            weaponCount++;
            player.GetWeaponCount(weaponCount);

            return true;
        }
        if (ability == "Damage +10%")
        {
            player.playerDamage = Mathf.CeilToInt(player.playerDamage * 1.1f);
            return true;
        }
        if (ability == "Fire Rate +10%")
        {
            player.timeBetweenShots -= player.timeBetweenShots * 0.1f;
            return true;
        }

        return false;
    }


}
