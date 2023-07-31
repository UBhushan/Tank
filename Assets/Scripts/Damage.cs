using UnityEngine;

public class Damage : MonoBehaviour
{
    //[SerializeField] private float defence = 2f;
    //[SerializeField] private int maxTouches = 2;

    [SerializeField] private float health = 70f;

    [SerializeField] private BlockType blockType;
    [SerializeField] private bool isSoldier = false;

    [SerializeField] private AudioClip woodSoundfx;
    [SerializeField] private AudioClip metalSoundfx;
    [SerializeField] private AudioClip concreteSoundfx;
    [SerializeField] private AudioClip soldierSoundfx;


    //private int touchCount = 0;


    private void OnCollisionEnter2D(Collision2D other) {

        #region  Old Damage        
        /*  Old Damage System
        if(touchCount >= maxTouches) SpawnParticlesDestory();

        if(other.relativeVelocity.magnitude > 1.5f) 
        { touchCount++; }

        if(other.relativeVelocity.magnitude > defence)
        {
            if(other.gameObject.tag == "ball")
            {
                other.rigidbody.velocity *= 0.45f;
            }

            SpawnParticlesDestory();
        }
        */
        #endregion

        float hitDamage = other.relativeVelocity.magnitude * 10f;

        if(other.gameObject.tag == "ball")
        {
            other.rigidbody.velocity *= 0.25f;
        }

        health = health - hitDamage;
        
        if(health <= 0f)
        {
            SpawnParticlesDestory();
        }
    }

    private void SpawnParticlesDestory()
    {
        if(isSoldier)
        {
            ParticleManager.instance.SpawnSoldierNumber(transform.position);
            SoundManager.instance.PlayAudioFx(soldierSoundfx);
        }

        switch (blockType)
        {
            case BlockType.wood:
            {
                ParticleManager.instance.SpawnSmoke(transform.position);
                ParticleManager.instance.SpawnWood(transform.position);
                ParticleManager.instance.SpawnWoodNumber(transform.position);

                SoundManager.instance.PlayAudioFx(woodSoundfx);

                break;
            }

            case BlockType.concrete:
            {
                ParticleManager.instance.SpawnSmoke(transform.position);
                ParticleManager.instance.SpawnConcrete(transform.position);
                

                if(!isSoldier)
                {
                    SoundManager.instance.PlayAudioFx(concreteSoundfx);
                    ParticleManager.instance.SpawnConcreteNumber(transform.position);
                }  

                break;
            }

            case BlockType.metal:
            {
                ParticleManager.instance.SpawnSmoke(transform.position);
                ParticleManager.instance.SpawnMetal(transform.position);
                ParticleManager.instance.SpawnMetalNumber(transform.position);

                SoundManager.instance.PlayAudioFx(metalSoundfx);

                break;
            }
            

            default:
                break;
        }

        Destroy(this.gameObject);
    }
}

public enum BlockType
{
    wood,
    concrete,
    metal
}
