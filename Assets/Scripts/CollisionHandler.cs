using UnityEngine;

public class Collosion : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    GameSceneManager gameSceneManager;

    void Start() {
         gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }


    void OnTriggerEnter(Collider other) {

        gameSceneManager.RestartLevel();  
        Instantiate(destroyVFX, transform.position, Quaternion.identity);   
        Destroy(gameObject);
          

    }
    
}
