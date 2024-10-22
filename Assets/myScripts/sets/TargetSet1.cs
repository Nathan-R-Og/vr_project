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


    void Start()
    {
        //iterate through all commands
        for (int i = 0; i < commands.Count; i++)
        {
            TargetDoer current = commands[i];
            for (int j = 1; j <= current.copies; j++)
            {
                //if copies > 0, make a new command copied from the current
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

    void Update()
    {
        //tick by one
        realTime += Time.deltaTime;
        for (int i = 0; i < commands.Count; i++)
        {
            TargetDoer current = commands[i];
            //if the command hasnt been executed and it is time to execute
            if (current.inTime <= realTime && !current.executed)
            {
                //execute and get percent range
                current.executed = true;
                float pick = UnityEngine.Random.Range(0.0f, 1.0f);
                
                //do the pick
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
