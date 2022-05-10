using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Scene_Database", menuName = "Scene Data/Database")]
public class ScenesData : ScriptableObject
{
    /// <summary>
    /// ���ݍ쐬����Ă��郌�x���ւ̎Q��
    /// </summary>
    public LevelScene startLevel;
    public LevelScene currentLevel;

    private void OnEnable()
    {
        Debug.Log("Enable");
        currentLevel = startLevel;
    }
    //Load a scene with a given name
    public void LoadLevelWithName(string name)
    {
        //Load Gameplay scene for the level
        SceneManager.LoadSceneAsync(name);
    }
    //Start next level
    public void NextLevel()
    {
        LoadLevelWithName(currentLevel.nextScene.sceneName);
        currentLevel = currentLevel.nextScene;
    }
    //Restart current level
    public void RestartLevel()
    {
        LoadLevelWithName(currentLevel.sceneName);
    }
    //New game, load level 1
    public void NewGame()
    {
        currentLevel = startLevel;
        LoadLevelWithName(currentLevel.sceneName);
    }
}
