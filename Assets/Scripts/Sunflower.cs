using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Sunflower : Plant
{
    // Start is called before the first frame update

    
    public float produceDuration = 5;
    private float produceTimer = 0;
    public GameObject sunPrefab;

    public float jumpMinDistance = 0.3f;
    public float jumpMaxDistance = 1.5f;

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected override void EnableUpdate()
    {
        produceTimer += Time.deltaTime;

        if (produceTimer > produceDuration)
        {
            produceTimer = 0;
            anim.SetTrigger("IsGlowing");
        }
    }
    public void BurnSun()
    {
        GameObject go= GameObject.Instantiate(sunPrefab,transform.position, Quaternion.identity);
        
        float distance =Random.Range(jumpMinDistance, jumpMaxDistance);
        distance = Random.Range(0, 2) < 1 ? -distance : distance;
        Vector3 position = transform.position;  
        position.x += distance;
        go.GetComponent<sun>().JumpTo(position);

    }

}
