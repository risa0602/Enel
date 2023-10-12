using UnityEngine;
using UnityEngine.SceneManagement;

public class SyncSkybox : MonoBehaviour
{
    public Material stage1Skybox;
    public Material stage2Skybox;
    public Material stage3Skybox;

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Stage1")
        {
            RenderSettings.skybox = stage1Skybox;
            SkyboxManager.previousSkybox = stage1Skybox;
        }
        else if (sceneName == "Stage2")
        {
            RenderSettings.skybox = stage2Skybox;
            SkyboxManager.previousSkybox = stage2Skybox;
        }
        else if (sceneName == "Stage3")
        {
            RenderSettings.skybox = stage3Skybox;
            SkyboxManager.previousSkybox = stage3Skybox;
        }
        else if (sceneName == "TitleCo")
        {
            if (SkyboxManager.previousSkybox != null)
            {
                RenderSettings.skybox = SkyboxManager.previousSkybox;
            }
        }
    }
}