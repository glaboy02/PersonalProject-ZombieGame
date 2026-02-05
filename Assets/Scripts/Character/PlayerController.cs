
using UnityEngine;

namespace RPG.Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int damageAmount = 20;
        public GameObject[] bullets;
        private float speed = 5f;
        private bool isDead = false;
        private float horizontalInput;
        private float verticalInput;
        private Animator playerAnim;
        private SpriteRenderer playerSprite;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            playerAnim = GetComponent<Animator>();
            playerSprite = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            if (horizontalInput != 0 || verticalInput != 0)
            {
                playerAnim.SetBool("isRunning", true);
                MovePlayer(Vector3.right, Vector3.up, horizontalInput, verticalInput);
            }
            else
            {
                playerAnim.SetBool("isRunning", false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FiringBullets();
            }

            
        }

        public void MovePlayer(Vector3 directionHorizontal, Vector3 directionVertical, float inputHorizontal, float inputVertical)
        {
            if (isDead) return;

            if (inputHorizontal < 0)
            {
                playerSprite.flipX = true;
            }
            else if (inputHorizontal > 0)
            {
                playerSprite.flipX = false;
            }

            transform.Translate(directionHorizontal * inputHorizontal * speed * Time.deltaTime);
            transform.Translate(directionVertical * inputVertical * speed * Time.deltaTime);
        }


        public void PlayerDead()
        {
            playerAnim.SetBool("Dead", true);
            Debug.Log("Player is dead.");
            isDead = true;
        }

        public void FiringBullets()
        {
            Instantiate(bullets[0], transform.position, Quaternion.identity);
        }
    }
}
