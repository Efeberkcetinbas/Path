using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionManager : MonoBehaviour
{
    public static SlowMotionManager Instance;

    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;

    bool canWork;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*void Update()
    {
        if (canWork)
        {
            //Statsta 40a kadar dusuruyor. 460 kez yazdirdi.
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
    }*/

    public void DoSlowmotion()
    {
        /*Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        canWork = true;*/
    }
}
