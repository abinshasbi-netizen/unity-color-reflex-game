using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class pooling : MonoBehaviour
{
    [SerializeField] private GameObject poolingPrefab;
    [SerializeField] private int poolsize;
    List<GameObject> pool = new List<GameObject>();
    
    Color[] colors = new Color[]
{
   new Color(0f, 0.6613998f, 1f, 1f),
   new Color(0f,1f,0.3267074f), 
   new Color(81f, 255f, 83f),
   new Color(0.6754716f, 0.1065255f, 0f, 1f),
};

    void Awake()
    {
        for (int i = 0; i < poolsize; i++) {

            
            GameObject obj = Instantiate(poolingPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        
        }
      }

    public GameObject GetFromPool() {


        foreach (GameObject obj in pool) {

            if (!obj.activeInHierarchy) {
                SpriteRenderer spriterenderer;
                spriterenderer = obj.GetComponent<SpriteRenderer>();
                int randomIndex = Random.Range(0, colors.Length);
                spriterenderer.color = colors[randomIndex];
                obj.SetActive(true);
                return obj;
            
            }
        
        }
        return null;
    
    }
    


   
}
