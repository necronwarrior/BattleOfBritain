using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlane : MonoBehaviour {

    public float health = 100.0f;
    public float damagePerSecond = 20.0f;

    private GeneralPlane adversary;


    private UnityEngine.Object explosionPrefab;


    void Awake() {
        explosionPrefab = Resources.Load("Prefabs/Explosion");

    }

    // Use this for initialization
    void Start()
    {
        adversary = null;


    }

    // Update is called once per frame
    void Update()
    {
        if (adversary != null) {
            DealDamage();
        }
    }

    void DealDamage() {

        adversary.TakeDamage(damagePerSecond * Time.deltaTime);

    }

    public void TakeDamage(float damage)
    {

        this.health -= damage;
        if (this.health <= 0.0f)
        {
            Die();
        }
    }

    public void StartDealingDamage(GeneralPlane otherPlane) {
        adversary = otherPlane;
    }

    public void StopDealingDamage() {
        adversary = null;
    }

    void Die()
    {

        GameObject explosion = (GameObject)Instantiate(explosionPrefab);

        explosion.transform.position = transform.position;

        Destroy(gameObject, 0.2f);

    }

}
