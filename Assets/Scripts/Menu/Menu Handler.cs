using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int levelcount;
    [SerializeField] private int unlockedlevels;

    [SerializeField] private GameObject contentsframe;
    [SerializeField] private GameObject prefab;

    [SerializeField] private CustomLevels[] customLevels;
    private List<GameObject> levelsgoarray = new();

 
    private void Refresh(){
        while (contentsframe.transform.childCount > 0){ // clears children to add new one
            DestroyImmediate(contentsframe.transform.GetChild(0).gameObject);
        }
        for (int i = 1; i < levelcount+1; i++){
            GameObject clonera = Instantiate(prefab,contentsframe.transform);
            if (clonera!=null){
                levelsgoarray.Add(clonera);
                ButtonHandler handl = clonera.GetComponent<ButtonHandler>();
                handl.butnid = i;
                handl.locked = true;
                if (i<=unlockedlevels){
                    handl.locked = false;
                    handl.stars = UnityEngine.Random.Range(0, 4);
                }
              
            }
        }
        foreach (CustomLevels customLevelsa in customLevels){
            if (levelsgoarray[customLevelsa.level-1] != null && levelsgoarray[customLevelsa.level-1].GetComponent<ButtonHandler>().locked == false){
                levelsgoarray[customLevelsa.level-1].GetComponent<ButtonHandler>().stars = customLevelsa.stars;
                if (customLevelsa.scene != null){
                    Debug.Log(customLevelsa.level-1);
                    levelsgoarray[customLevelsa.level-1].GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(customLevelsa.scene.name));
                }
            }
        }
    }
    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
}

[System.Serializable]
public class CustomLevels{
   public int level;
   public int stars;
   
   public SceneAsset scene;
}