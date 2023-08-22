using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkyPoolerGen : MonoBehaviour
{
    public AnimationCurve scoreDifficulty;
    public GameObject[] tier1Enemys;
    public GameObject[] tier2Enemys;
    public GameObject[] tier3Enemys;
    public int[] scoreGaps;
    public int poolSize;
    public float spawnRate;
    public float applyScoreDifficulty = 0f;
    public float applyRandomDifficulty = 0f;

    public GameObject justSpawned;



    private GameObject[] allEnemys;
    private int spotInArrayObjAboutToBeSpawned;
    private int indexOfSpawnObj;
    private int randomTier;

    protected float spawnRateBorder;
    protected Pooler _tier1 = new Pooler();
    protected Pooler _tier2 = new Pooler();
    protected Pooler _tier3 = new Pooler();
    protected float _time;
    protected GameObject _mainObj;
    protected Vars _mainVars;
    protected float _squareRootScoreApply;

    
    protected private GameObject CreateObj(GameObject baseObj)
    {
        return Instantiate(baseObj);
    }


    protected private void DisableGO(GameObject g)
    {
        try {
            if (g != null) 
            {
                Pooler t = _tier1.GetSiblingPool(g.name);
                if (t == null) t = _tier2.GetSiblingPool(g.name);
                if (t == null) t = _tier3.GetSiblingPool(g.name);
                g.SendMessage("Disable");
                t.Add(g);   
            }
        }
        catch (System.Exception e) {
            g = g.transform.parent.gameObject;
            if (g != null) 
            {
                Pooler t = _tier1.GetSiblingPool(g.name);
                if (t == null) t = _tier2.GetSiblingPool(g.name);
                if (t == null) t = _tier3.GetSiblingPool(g.name);
                g.SendMessage("Disable");
                t.Add(g);   
            }
        }
    }

    protected private void Enable(GameObject g)
    {
        if (g != null)
        {
            g.active = true;
            g.SendMessage("Enable");
        }
    }

    protected void CreateClones(GameObject[] tierl, ref Pooler tierp)
    {
        foreach (GameObject original in tierl)
        {
            tierp.CreateSiblingPool(original.name + "(Clone)");
            for (int i=0; i<poolSize; i++)
            {
                DisableGO(CreateObj(original));
            }
        }
    }

    protected void Start()
    {
        _mainObj = GameObject.Find("Main");
        _mainVars = _mainObj.GetComponent<Vars>();

        CreateClones(tier1Enemys, ref _tier1);
        CreateClones(tier2Enemys, ref _tier2);
        CreateClones(tier3Enemys, ref _tier3);
        _time = 0;

        //Write all enemyTypes into Main Vars
        _mainVars.everyEnemyArray = tier1Enemys.Concat(tier2Enemys.Concat(tier3Enemys).ToArray()).ToArray();
        _mainVars.everyEnemyStringArr = new string[_mainVars.everyEnemyArray.Length];

        for(int i = 0; i < _mainVars.everyEnemyArray.Length; i++)
        {
            //Debug.Log("The element in index " + i + " is " + _mainVars.everyEnemyArray[i]);

            _mainVars.everyEnemyStringArr[i] = _mainVars.everyEnemyArray[i].name;
            //Debug.Log(_mainVars.everyEnemyStringArr[i]);
           
        }
        //Array.Copy(tier1Enemys, _mainVars.everyEnemyArray, tier1Enemys.Length);
        
        //Debug.Log(_mainVars.everyEnemyArray[14]);



        //Erster Gegner spawnt um...
        spawnRateBorder = 0.5f;
    }
    
    protected void Update()
    {   
        if(Time.time - _time >= spawnRateBorder)
        {
            int allowed_tiers = 1;
            int numberOfAllowedEnemys = tier1Enemys.Length;
            
            foreach(var i in scoreGaps)
            {
                if (_mainVars.scoreInt >= i) allowed_tiers++;
                else break;
            }

            if (allowed_tiers > 1) numberOfAllowedEnemys += tier2Enemys.Length;
            if (allowed_tiers > 2) numberOfAllowedEnemys += tier3Enemys.Length;
            
            randomTier = Random.Range(0, numberOfAllowedEnemys);

            GameObject g = null;


            
            if (randomTier >= tier1Enemys.Length + tier2Enemys.Length) {
                indexOfSpawnObj = Random.Range(0, tier3Enemys.Length);
                g = _tier3.GetSiblingPool(tier3Enemys[indexOfSpawnObj].name + "(Clone)").RequestPeek();
            }
            else if (randomTier >= tier1Enemys.Length) {
                indexOfSpawnObj = Random.Range(0, tier2Enemys.Length);
                g = _tier2.GetSiblingPool(tier2Enemys[indexOfSpawnObj].name + "(Clone)").RequestPeek();
            }
            else {
                indexOfSpawnObj = Random.Range(0, tier1Enemys.Length);
                g = _tier1.GetSiblingPool(tier1Enemys[indexOfSpawnObj].name + "(Clone)").RequestPeek();
            }

            //randomTier = 10;
            //indexOfSpawnObj = 4;
            //g = _tier2.GetSiblingPool(tier2Enemys[4].name + "(Clone)").RequestPeek();

            justSpawned = null;

            Enable(CheckIfEnemySpawnIsFair(g));
            //print(justSpawned);
            int randoInt = Random.Range(0,4);
            //print(randoInt);
            switch(randoInt) {
                case 0: justSpawned.SendMessage("SetDirLeft"); break;
                case 1: justSpawned.SendMessage("SetDirRight"); break;
                case 2: justSpawned.SendMessage("SetDirUp"); break;
                case 3: justSpawned.SendMessage("SetDirDown"); break;

            justSpawned.GetComponent<NewBaseSkyE>().ActivateEnemy();

        }
        

            //Feststellen wann der nächste Gegner spawnt
            GenerateNextSpawnBorder();
            _time = Time.time;
        }
        else {

        }
        
    }

    void GenerateNextSpawnBorder() {
        //_squareRootScoreApply = (float)(Mathf.Sqrt(_mainVars.scoreInt-4500) / 38.72f);
        //Debug.Log("sqaureRootMultiplier: " + _squareRootScoreApply);
        //applyScoreDifficulty = _squareRootScoreApply;
        applyScoreDifficulty = scoreDifficulty.Evaluate((float)_mainVars.scoreInt/10000f);
        ApplyRandomDifficultyFunction(); 
        spawnRateBorder = spawnRate + applyScoreDifficulty + applyRandomDifficulty;
    }

    void ApplyRandomDifficultyFunction() {
        //if(_mainVars.scoreInt < 2000) {         applyRandomDifficulty = (float)(Random.Range(-30,11) / 100f); }
        //    else if(_mainVars.scoreInt > 2000) {
        applyRandomDifficulty = (float)(Random.Range(-20,21) / 100f);
    }

    GameObject CheckIfEnemySpawnIsFair(GameObject objAboutToBeSpawned) {

        //newObjToSpawn will return in this function and get requested. Wenn nix unfair ist gilt newObjToSpawn = objAboutToBeSpawned
        GameObject newObjToSpawn = objAboutToBeSpawned;
        justSpawned = _tier1.GetSiblingPool(tier1Enemys[indexOfSpawnObj].name + "(Clone)").RequestObj();
        newObjToSpawn = justSpawned;
        return newObjToSpawn;

    }
}
