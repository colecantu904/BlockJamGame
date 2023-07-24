using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    [Header("Wave Settings")]
    [SerializeField] public float delay = 3f;
    [SerializeField] public float waveTime = 35f;
    [Header("Slime Settings")]
    [SerializeField] public float delaySlime = 3f;
    [SerializeField]public int slimeAmount = 3;
    private int spawnedSlime = 0;
    [Header("Blue Slime Settings")]
    [SerializeField] public float delayBlueSlime = 3f;
    [SerializeField] public int blueSlimeAmount = 3;
    private int spawnedBlueSlime = 0;
    [Header("Red Settings")]
    [SerializeField] public float delayRed = 3f;
    [SerializeField] public int redAmount = 3;
    private int spawnedRed = 0;
    [Header("Yellow")]
    public float delayYellow = 3f;
    public int yellowAmount = 3;
    private int spawnedYellow;

    [Header("Enemies")]
    public GameObject slime;
    public GameObject blueslime;
    public GameObject red;
    public GameObject Yellow;

    public int wave;

    private void Awake()
    {
        playerMain playerMain = FindObjectOfType<playerMain>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waves());
        delay = waveTime;
    }

    private IEnumerator Waves()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            StartCoroutine(Slimes());
            //StartCoroutine(BlueSlimes());
            StartCoroutine(Reds());
            StartCoroutine(Yellows());

            wave++;

            if (wave % 2 == 0)
            {
                FindObjectOfType<playerMain>().HealthScript.health += 7;
            }

        }
    }

    private IEnumerator Slimes()
    {
        while (spawnedSlime<slimeAmount + wave)
        {
            yield return new WaitForSeconds(delaySlime);
            Instantiate(slime, transform.position, transform.rotation);
            spawnedSlime++;
        }
        spawnedSlime = 0;
    }
    private IEnumerator BlueSlimes()
    {
        while (spawnedBlueSlime < blueSlimeAmount + wave)
        {
            yield return new WaitForSeconds(delayBlueSlime);
            Instantiate(blueslime, transform.position, transform.rotation);
            spawnedBlueSlime++;
        }
        spawnedBlueSlime = 0;
    }
    private IEnumerator Reds()
    {
        while (spawnedRed < redAmount + wave)
        {
            yield return new WaitForSeconds(delayRed);
            Instantiate(red, transform.position, transform.rotation);
            spawnedRed++;
        }
        spawnedRed = 0;
    }
    IEnumerator Yellows()
    {
        while (spawnedYellow < yellowAmount + wave)
        {
            yield return new WaitForSeconds(delayYellow);
            Instantiate(Yellow, transform.position, transform.rotation);
            spawnedYellow++;
        }
        spawnedYellow = 0;
    }
}
