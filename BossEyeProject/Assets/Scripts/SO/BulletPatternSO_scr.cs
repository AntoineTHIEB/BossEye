using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletPattern")]
public class BulletPatternSO_scr : ScriptableObject
{
    [Serializable] public class BulletImpulse
    {
        public float timeBeforePattern;
        public CruveSO_scr bulletPattern;
        public int nbBulletPerImpulse;
        public float diffAngleBetweenBullets;
        public float timeBetweenImpulses;
        public float diffAngleFromPreviousImpulse;
    }
    public BulletImpulse[] Impulse;
}