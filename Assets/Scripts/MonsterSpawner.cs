using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int spawned = 0;
    public  bool complete = false;
    public int killed;
    public int totalamount;
    

    public void Update()
    {
        if (spawned > 0 && killed == totalamount)
        {
            complete = true;
            spawned = 0;
            killed = 0;
        }
    }
    public void SpawnMonsters(int amount, Vector3 position)
    {
        totalamount = amount;

        foreach (GameObject enemy in enemyPrefabs)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.transform.position = position;
                enemy.SetActive(true);

                Debug.Log("Spawn: " + enemy.name);

                spawned++;
                if (spawned >= amount)
                
                    return;
                

                
            }
        }

        Debug.Log("No hay suficientes monstruos libres en la pool");
    }
}
