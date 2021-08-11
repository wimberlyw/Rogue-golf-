using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //[SerializeField] private GameObject ballPrefab;
    [SerializeField] private LevelData[] levelDatas;

    public LevelData[] LevelDatas{get {return levelDatas;}}
    private int shotCount = 0;

public void SpawnLevel(int levelIndex)
{
    Instantiate(levelDatas[levelIndex].levelPrefab, Vector3.zero, Quaternion.identity);
    shotCount = levelDatas[levelIndex].shotLimit;
    //Vector3 menuSPawn = new Vector3 (0f,.5f,2f);
    //GameObject ball = Instantiate(ballPrefab, menuSPawn, Quaternion.identity);
    //GameManager.singleton.gameStatus = GameManager.GameStatus.PLAYING;
}

/*public void shotTaken()
{
    if( shotCount>0)
    {
        shotCount--;
        if(shotCount<=0)
        {
            GameManager.singleton.gameStatus = GameManager.GameStatus.FAILED;
        }

    }
}

void Start()
{
    SpawnLevel(GameManager.singleton.currentLevelIndex);
}
*/


}
