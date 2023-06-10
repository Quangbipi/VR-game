using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // hp nguoi choi
        public GameObject enemy;                // 
        public float spawnTime = 3f;            // thoi gian spawn enemy
        public Transform[] spawnPoints;         // diem spawwn


        void Start ()
        {
            // sd de goi ham Spwan
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }


        void Spawn ()
        {
            // neu hp player het
            if(playerHealth.currentHealth <= 0f)
            {
               
                return;
            }

            // random diem spawn
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);

            // Tao enemy
            Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}