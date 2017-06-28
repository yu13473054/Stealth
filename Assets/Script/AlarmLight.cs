using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour {
    public float fadeSpeed=2;//灯光变化的速度
    public float highIntensity = 2;//最大强度
    public float lowIntensity=0.5f;
    public float changeMargin = 0.2f;//灯光强度变化的判断阀值
    public bool alarmOn;

    private float targetIntensity;

    Light light;

    void Awake()
    {
        light = GetComponent<Light>();
        light.intensity = 0;
        targetIntensity = highIntensity;
    }

    void Update()
    {
        if (alarmOn)
        {
            light.intensity = Mathf.Lerp(light.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
            CheckTargetIntensity();
        }else {
            light.intensity = Mathf.Lerp(light.intensity, 0, fadeSpeed * Time.deltaTime);

        }
    }

    void CheckTargetIntensity()
    {
        if(Mathf.Abs(light.intensity-targetIntensity)<changeMargin){
            if (targetIntensity==highIntensity)
            {
                targetIntensity = lowIntensity;
            }
            else
            {
                targetIntensity = highIntensity;
            }
        }
    }
}
