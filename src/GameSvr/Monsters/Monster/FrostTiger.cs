﻿using SystemModule;

namespace GameSvr
{
    public class FrostTiger : Monster
    {
        public FrostTiger() : base()
        {
            m_dwSearchTime = M2Share.RandomNumber.Random(1500) + 1500;
        }

        public override void Run()
        {
            if (!m_boDeath && !bo554 && !m_boGhost && m_wStatusTimeArr[Grobal2.POISON_STONE] == 0)
            {
                if (m_TargetCret == null)
                {
                    if (m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] == 0)
                    {
                        M2Share.MagicManager.MagMakePrivateTransparent(this, 180);
                    }
                }
                else
                {
                    m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 0;
                }
                if ((HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 8000 || (HUtil32.GetTickCount() - m_dwSearchEnemyTick) > 1000 && m_TargetCret == null)
                {
                    m_dwSearchEnemyTick = HUtil32.GetTickCount();
                    SearchTarget();
                }
            }
            base.Run();
        }
    }
}

