using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public static AbilityController Instance;

    [Header("Ability Card Arrays")]
    [SerializeField] private GameObject[] abilityCard1;
    [SerializeField] private GameObject[] abilityCard2;
    [SerializeField] private GameObject[] abilityCard3;

    // [Header("Spawn Points")]
    // [SerializeField] private Transform[] cardSpawnPoints;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private int GetRandomAbilityCardIndex(int arrayLength)
    {
        return Random.Range(0, arrayLength);
    }

    public void SpawnAbilityCards()
    {
        

        // First, deactivate ALL cards in all arrays
        if (abilityCard1 != null)
        {
            foreach (GameObject card in abilityCard1)
            {
                if (card != null) card.SetActive(false);
            }
        }

        if (abilityCard2 != null)
        {
            foreach (GameObject card in abilityCard2)
            {
                if (card != null) card.SetActive(false);
            }
        }

        if (abilityCard3 != null)
        {
            foreach (GameObject card in abilityCard3)
            {
                if (card != null) card.SetActive(false);
            }
        }

        // Then activate ONE random card from each array
        for (int i = 0; i < abilityCard1.Length; i++)
        {
            if (i == 0 && abilityCard1 != null && abilityCard1.Length > 0)
            {
                int randomIndex = GetRandomAbilityCardIndex(abilityCard1.Length);
                abilityCard1[randomIndex].SetActive(true);
            }
            else if (i == 1 && abilityCard2 != null && abilityCard2.Length > 0)
            {
                int randomIndex = GetRandomAbilityCardIndex(abilityCard2.Length);
                abilityCard2[randomIndex].SetActive(true);
            }
            else if (i == 2 && abilityCard3 != null && abilityCard3.Length > 0)
            {
                int randomIndex = GetRandomAbilityCardIndex(abilityCard3.Length);
                abilityCard3[randomIndex].SetActive(true);
            }
        }
    }

}
