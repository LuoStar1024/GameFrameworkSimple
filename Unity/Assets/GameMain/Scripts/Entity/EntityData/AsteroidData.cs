//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using GameConfig;
using UnityEngine;

namespace StarForce
{
    [Serializable]
    public class AsteroidData : TargetableObjectData
    {
        [SerializeField]
        private int m_MaxHP = 0;

        [SerializeField]
        private int m_Attack = 0;

        [SerializeField]
        private float m_Speed = 0f;

        [SerializeField]
        private float m_AngularSpeed = 0f;

        [SerializeField]
        private int m_DeadEffectId = 0;

        [SerializeField]
        private int m_DeadSoundId = 0;

        public AsteroidData(int entityId, int typeId)
            : base(entityId, typeId, CampType.Neutral)
        {
            var cfgAsteroid = GameEntry.Luban.Tables.TbAsteroid.Get(TypeId);
            if (cfgAsteroid == null)
            {
                return;
            }

            HP = m_MaxHP = cfgAsteroid.MaxHp;
            m_Attack = cfgAsteroid.Attack;
            m_Speed = cfgAsteroid.Speed;
            m_AngularSpeed = cfgAsteroid.AngularSpeed;
            m_DeadEffectId = cfgAsteroid.DeadEffectId;
            m_DeadSoundId = cfgAsteroid.DeadSoundId;
        }

        public override int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
        }

        public int Attack
        {
            get
            {
                return m_Attack;
            }
        }

        public float Speed
        {
            get
            {
                return m_Speed;
            }
        }

        public float AngularSpeed
        {
            get
            {
                return m_AngularSpeed;
            }
        }

        public int DeadEffectId
        {
            get
            {
                return m_DeadEffectId;
            }
        }

        public int DeadSoundId
        {
            get
            {
                return m_DeadSoundId;
            }
        }
    }
}
