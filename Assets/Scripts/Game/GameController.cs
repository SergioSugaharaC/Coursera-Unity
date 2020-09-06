using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{
    // Variables
    private float timeElapsed = 0f;
    private float Rate = 1.0f;
    float screenAspect, halfHeight;
    float startX, startY;

    // Candy Variables
    [Header("Candy pool")]
    [SerializeField] private List<GameObject> Candies = new List<GameObject>();
    private List<GameObject> poolCandies = new List<GameObject>();

    // Bullet Variables
    [Header("Bullet Pools")]
    [SerializeField] private GameObject Bullet;
    private List<GameObject> poolBullet = new List<GameObject>();

    // Singleton
    public static GameController instance;

    private void Awake() {
        if (instance == null) instance = this;
    }
    

    // Start is called before the first frame update
    void Start(){
        screenAspect = (float)Screen.width / (float)Screen.height;
        halfHeight = Camera.main.orthographicSize;
        startX = screenAspect * halfHeight;
        GenerateCandyPool();
        GenerateBulletPool();
    }

    void GenerateCandyPool(){
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < Candies.Count; j++){
                GameObject Obstacle = Instantiate(Candies[i], new Vector3(startX, -3.5f, 1.0f), Quaternion.identity);
                //Obstacle.transform.localScale = new Vector3(0.5f * scale, 0.5f, 1.0f);
                Obstacle.SetActive(false);
                poolCandies.Add(Obstacle);
            }
    }

    private void GenerateBulletPool(){
        for (int j = 0; j < 20; j++){
            GameObject go = Instantiate(Bullet, transform.position, Quaternion.identity);
            go.SetActive(false);
            poolBullet.Add(go);
        }
    }

    // Update is called once per frame
    void Update(){
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= Rate){
            Rate = Random.Range(1.0f, 3.0f);
            timeElapsed = 0f;
            GetFirstDeadCandy();
        }
    }

    void GetFirstDeadCandy(){
        startY = Random.Range(-halfHeight, halfHeight);
        while (true){
            int index = Random.Range(0, poolCandies.Count - 1);
            if (!poolCandies[index].activeInHierarchy){
                poolCandies[index].SetActive(true);
                poolCandies[index].transform.position = new Vector3(startX, startY, 0);
                break;
            }
        }
    }

    public void CandyFire(Vector3 startPos){
        while (true){
            int index = Random.Range(0, poolBullet.Count - 1);
            if (!poolBullet[index].activeInHierarchy){
                poolBullet[index].SetActive(true);
                poolBullet[index].transform.position = startPos;
                poolBullet[index].GetComponent<Bullet>().Shooting("L");
                break;
            }
        }
    }

    public void PlayerFire(Vector3 startPos){
        while (true){
            int index = Random.Range(0, poolBullet.Count - 1);
            if (!poolBullet[index].activeInHierarchy){
                poolBullet[index].SetActive(true);
                poolBullet[index].transform.position = startPos;
                poolBullet[index].GetComponent<Bullet>().Shooting("R");
                break;
            }
        }
    }
}
