using UnityEngine;
using System.Collections;

public class ShowFPS : MonoBehaviour {
    private float time;
    private float fpsCount = 0.0f;
    private float foo = 0.0f;
    private float framesPerSecound;
	// Use this for initialization
	void Start () {
        time = Time.time;
        Application.targetFrameRate = 600;
        QualitySettings.vSyncCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        FPS();
	}
    void FPS()
    {
        fpsCount++;
        foo = Time.time;
        if (foo-time >= 1f)
        {
            time = foo;
            framesPerSecound = fpsCount;
            fpsCount = 0;
        }

        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 128, 64, 32, 32), "FPS: ");
        GUI.Label(new Rect(Screen.width - 96, 64, 128, 32), framesPerSecound.ToString());
    }
}
