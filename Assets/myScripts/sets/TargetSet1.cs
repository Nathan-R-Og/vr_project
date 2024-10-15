using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[System.Serializable]
public class TargetRate
{
    public Target TargetType;
    public float Rate;
}

[System.Serializable]
public class TargetDoer
{
    public List<TargetRate> rates;
    public string animation;
    public Vector3 start;
    public float inTime;
    public bool executed = false;
    public int copies = 0;
    public float copyDelay = 0;
    public float speedScale = 1;
}

public class TargetSet1 : MonoBehaviour
{
    public float realTime = 0.0f;
    [SerializeField]
    public List<TargetDoer> commands;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < commands.Count; i++)
        {
            TargetDoer current = commands[i];
            for (int j = 1; j <= current.copies; j++)
            {
                TargetDoer newClone = new TargetDoer();
                newClone.rates = current.rates;
                newClone.animation = current.animation;
                newClone.speedScale = current.speedScale;
                newClone.start = current.start;
                newClone.inTime = current.inTime + (current.copyDelay * j);
                commands.Add(newClone);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        realTime += Time.deltaTime;
        for (int i = 0; i < commands.Count; i++)
        {
            TargetDoer current = commands[i];
            if (current.inTime <= realTime && !current.executed)
            {
                current.executed = true;
                float pick = UnityEngine.Random.Range(0.0f, 1.0f);
                
                for(int rate = 0; rate < current.rates.Count; rate++)
                {
                    if (pick <= current.rates[rate].Rate)
                    {
                        Target newTarget = Instantiate(current.rates[rate].TargetType, current.start, new Quaternion());
                        newTarget.speedScale = current.speedScale;
                        newTarget.PlayAnimation(current.animation);
                        break;
                    }
                }
            }

        }

    }

}
