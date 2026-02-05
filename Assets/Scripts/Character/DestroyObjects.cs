using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private float upperBound = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > upperBound)
        {
            Destroy(gameObject);
        }
    }
}
