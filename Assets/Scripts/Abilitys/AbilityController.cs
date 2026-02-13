using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public GameObject[] abilityCard1;
    public GameObject[] abilityCard2;
    public GameObject[] abilityCard3;
    public Transform[] cardSpawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnAbilityCards();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int GetRandomAbilityCardIndex()
    {
        return Random.Range(0, abilityCard1.Length);
    }

    public void SpawnAbilityCards()
    {
        for (int i = 0; i < cardSpawnPoints.Length; i++)
        {
            if (i == 0)
            {
                abilityCard1[GetRandomAbilityCardIndex()].gameObject.SetActive(true);
            }
            else if (i == 1)
            {
                abilityCard2[GetRandomAbilityCardIndex()].gameObject.SetActive(true);
            }
            else if (i == 2)
            {
                abilityCard3[GetRandomAbilityCardIndex()].gameObject.SetActive(true);
            }
        }

    }

}
