using System.Collections.Generic;

namespace GameFramework.Timer
{
    internal sealed partial class TimerManager : GameFrameworkModule, ITimerManager
    {
        private int m_SerialId = 0;

        private readonly List<Timer> m_TimerList = new List<Timer>();
        private readonly List<Timer> m_UnscaledTimerList = new List<Timer>();
        private readonly List<int> m_CacheRemoveTimerList = new List<int>();
        private readonly List<int> m_CacheRemoveUnscaledTimerList = new List<int>();

        /// <summary>
        /// 定时器轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        internal override void Update(float elapseSeconds, float realElapseSeconds)
        {
            UpdateTimer(elapseSeconds);
            UpdateUnscaledTimer(realElapseSeconds);
        }

        /// <summary>
        /// 关闭并清理定时器。
        /// </summary>
        internal override void Shutdown()
        {
            RemoveAllTimer();
        }

        /// <summary>
        /// 添加定时器。
        /// </summary>
        /// <param name="time">时间间隔。</param>
        /// <param name="repeatCount">调用次数，小于等于0为无限。</param>
        /// <param name="isUnscaled">是否不受时间缩放影响。</param>
        /// <param name="callback">回调。</param>
        /// <param name="args">传参。（避免闭包）</param>
        /// <returns>计算器ID。</returns>
        public int AddTimer(float time, GameFrameworkActionArgs callback, int repeatCount = 1, bool isUnscaled = false,
            params object[] args)
        {
            m_SerialId++;

            Timer timer = Timer.Create(m_SerialId, time, repeatCount, isUnscaled, callback, args);
            InsertTimer(timer);

            return timer.ID;
        }

        /// <summary>
        /// 暂停计时器。
        /// </summary>
        /// <param name="timerId">计时器Id。</param>
        public void StopTimer(int timerId)
        {
            Timer timer = GetTimer(timerId);
            if (timer != null) timer.IsRunning = false;
        }

        /// <summary>
        /// 恢复计时器。
        /// </summary>
        /// <param name="timerId">计时器Id。</param>
        public void ResumeTimer(int timerId)
        {
            Timer timer = GetTimer(timerId);
            if (timer != null) timer.IsRunning = true;
        }

        /// <summary>
        /// 计时器是否在运行中。
        /// </summary>
        /// <param name="timerId">计时器Id。</param>
        /// <returns>否在运行中。</returns>
        public bool IsRunning(int timerId)
        {
            Timer timer = GetTimer(timerId);
            return timer is { IsRunning: true };
        }

        /// <summary>
        /// 获得计时器剩余时间。
        /// </summary>
        public float GetLeftTime(int timerId)
        {
            Timer timer = GetTimer(timerId);
            if (timer == null) return 0;
            return timer.CurTime;
        }

        /// <summary>
        /// 重置计时器,恢复到开始状态。
        /// </summary>
        public void Restart(int timerId)
        {
            Timer timer = GetTimer(timerId);
            if (timer != null)
            {
                timer.CurTime = timer.Time;
                timer.IsRunning = true;
            }
        }

        /// <summary>
        /// 重置计时器。
        /// </summary>
        /// <param name="timerId">定时器ID。</param>
        /// <param name="time">时间间隔。</param>
        /// <param name="callback">回调。</param>
        /// <param name="repeatCount">调用次数，小于等于0为无限。</param>
        /// <param name="isUnscaled">是否不受时间缩放影响。</param>
        public void Reset(int timerId, float time, GameFrameworkActionArgs callback, int repeatCount = 1,
            bool isUnscaled = false)
        {
            Timer timer = GetTimer(timerId);
            if (timer != null)
            {
                timer.CurTime = time;
                timer.Time = time;
                timer.Callback = callback;
                timer.RepeatCount = repeatCount;
                timer.IsNeedRemove = false;
                if (timer.IsUnscaled != isUnscaled)
                {
                    RemoveTimerImmediate(timerId);

                    timer.IsUnscaled = isUnscaled;
                    InsertTimer(timer);
                }
            }
        }

        /// <summary>
        /// 重置计时器。
        /// </summary>
        /// <param name="timerId">定时器ID。</param>
        /// <param name="time">时间间隔。</param>
        /// <param name="repeatCount">调用次数，小于等于0为无限。</param>
        /// <param name="isUnscaled">是否不受时间缩放影响。</param>
        public void Reset(int timerId, float time, int repeatCount = 1, bool isUnscaled= false)
        {
            Timer timer = GetTimer(timerId);
            if (timer != null)
            {
                timer.CurTime = time;
                timer.Time = time;
                timer.RepeatCount = repeatCount;
                timer.IsNeedRemove = false;
                if (timer.IsUnscaled != isUnscaled)
                {
                    RemoveTimerImmediate(timerId);

                    timer.IsUnscaled = isUnscaled;
                    InsertTimer(timer);
                }
            }
        }

        /// <summary>
        /// 移除计时器。
        /// </summary>
        /// <param name="timerId">计时器Id。</param>
        public void RemoveTimer(int timerId)
        {
            for (int i = 0, len = m_TimerList.Count; i < len; i++)
            {
                if (m_TimerList[i].ID == timerId)
                {
                    m_TimerList[i].IsNeedRemove = true;
                    return;
                }
            }

            for (int i = 0, len = m_UnscaledTimerList.Count; i < len; i++)
            {
                if (m_UnscaledTimerList[i].ID == timerId)
                {
                    m_UnscaledTimerList[i].IsNeedRemove = true;
                    return;
                }
            }
        }

        /// <summary>
        /// 移除所有计时器。
        /// </summary>
        public void RemoveAllTimer()
        {
            for (int i = 0, len = m_TimerList.Count; i < len; i++)
            {
                ReferencePool.Release(m_TimerList[i]);
            }

            m_TimerList.Clear();

            for (int i = 0, len = m_UnscaledTimerList.Count; i < len; i++)
            {
                ReferencePool.Release(m_UnscaledTimerList[i]);
            }

            m_UnscaledTimerList.Clear();
        }

        private void InsertTimer(Timer timer)
        {
            bool isInsert = false;
            if (timer.IsUnscaled)
            {
                for (int i = 0, len = m_UnscaledTimerList.Count; i < len; i++)
                {
                    if (m_UnscaledTimerList[i].CurTime > timer.CurTime)
                    {
                        m_UnscaledTimerList.Insert(i, timer);
                        isInsert = true;
                        break;
                    }
                }

                if (!isInsert)
                {
                    m_UnscaledTimerList.Add(timer);
                }
            }
            else
            {
                for (int i = 0, len = m_TimerList.Count; i < len; i++)
                {
                    if (m_TimerList[i].CurTime > timer.CurTime)
                    {
                        m_TimerList.Insert(i, timer);
                        isInsert = true;
                        break;
                    }
                }

                if (!isInsert)
                {
                    m_TimerList.Add(timer);
                }
            }
        }

        /// <summary>
        /// 立即移除。
        /// </summary>
        /// <param name="timerId">ID</param>
        private void RemoveTimerImmediate(int timerId)
        {
            for (int i = 0, len = m_TimerList.Count; i < len; i++)
            {
                if (m_TimerList[i].ID == timerId)
                {
                    m_TimerList.RemoveAt(i);
                    return;
                }
            }

            for (int i = 0, len = m_UnscaledTimerList.Count; i < len; i++)
            {
                if (m_UnscaledTimerList[i].ID == timerId)
                {
                    m_UnscaledTimerList.RemoveAt(i);
                    return;
                }
            }
        }

        private Timer GetTimer(int timerId)
        {
            for (int i = 0, len = m_TimerList.Count; i < len; i++)
            {
                if (m_TimerList[i].ID == timerId)
                {
                    return m_TimerList[i];
                }
            }

            for (int i = 0, len = m_UnscaledTimerList.Count; i < len; i++)
            {
                if (m_UnscaledTimerList[i].ID == timerId)
                {
                    return m_UnscaledTimerList[i];
                }
            }

            return null;
        }

        private void LoopCallInBadFrame()
        {
            bool isLoopCall = false;
            for (int i = 0, len = m_TimerList.Count; i < len; i++)
            {
                Timer timer = m_TimerList[i];
                
                if (timer.IsNeedRemove) continue;
                if (timer.CurTime <= 0)
                {
                    timer.Callback?.Invoke(timer.Args);
                    timer.RepeatCount--;
                    
                    if (timer.RepeatCount != 0)
                    {
                        timer.CurTime += timer.Time;
                        if (timer.CurTime <= 0)
                        {
                            isLoopCall = true;
                        }
                    }
                    else
                    {
                        timer.IsNeedRemove = true;
                    }
                }
            }

            if (isLoopCall)
            {
                LoopCallInBadFrame();
            }
        }

        private void LoopCallUnscaledInBadFrame()
        {
            bool isLoopCall = false;
            for (int i = 0, len = m_UnscaledTimerList.Count; i < len; i++)
            {
                Timer timer = m_UnscaledTimerList[i];
                
                if (timer.IsNeedRemove) continue;
                if (timer.CurTime <= 0)
                {
                    timer.Callback?.Invoke(timer.Args);
                    timer.RepeatCount--;
                    
                    if (timer.RepeatCount != 0)
                    {
                        timer.CurTime += timer.Time;
                        if (timer.CurTime <= 0)
                        {
                            isLoopCall = true;
                        }
                    }
                    else
                    {
                        timer.IsNeedRemove = true;
                    }
                }
            }

            if (isLoopCall)
            {
                LoopCallUnscaledInBadFrame();
            }
        }

        private void UpdateTimer(float elapseSeconds)
        {
            bool isLoopCall = false;
            for (int i = 0, len = m_TimerList.Count; i < len; i++)
            {
                Timer timer = m_TimerList[i];
                if (timer.IsNeedRemove)
                {
                    m_CacheRemoveTimerList.Add(i);
                    continue;
                }

                if (!timer.IsRunning) continue;
                timer.CurTime -= elapseSeconds;
                if (timer.CurTime <= 0)
                {
                    timer.Callback?.Invoke(timer.Args);
                    timer.RepeatCount--;

                    if (timer.RepeatCount != 0)
                    {
                        timer.CurTime += timer.Time;
                        if (timer.CurTime <= 0)
                        {
                            isLoopCall = true;
                        }
                    }
                    else
                    {
                        m_CacheRemoveTimerList.Add(i);
                    }
                }
            }

            for (int i = m_CacheRemoveTimerList.Count - 1; i >= 0; i--)
            {
                Timer timer = m_TimerList[m_CacheRemoveTimerList[i]];
                m_TimerList.RemoveAt(m_CacheRemoveTimerList[i]);
                m_CacheRemoveTimerList.RemoveAt(i);
                ReferencePool.Release(timer);
            }

            if (isLoopCall)
            {
                LoopCallInBadFrame();
            }
        }

        private void UpdateUnscaledTimer(float realElapseSeconds)
        {
            bool isLoopCall = false;
            for (int i = 0, len = m_UnscaledTimerList.Count; i < len; i++)
            {
                Timer timer = m_UnscaledTimerList[i];
                if (timer.IsNeedRemove)
                {
                    m_CacheRemoveUnscaledTimerList.Add(i);
                    continue;
                }

                if (!timer.IsRunning) continue;
                timer.CurTime -= realElapseSeconds;
                if (timer.CurTime <= 0)
                {
                    timer.Callback?.Invoke(timer.Args);
                    timer.RepeatCount--;

                    if (timer.RepeatCount != 0)
                    {
                        timer.CurTime += timer.Time;
                        if (timer.CurTime <= 0)
                        {
                            isLoopCall = true;
                        }
                    }
                    else
                    {
                        m_CacheRemoveUnscaledTimerList.Add(i);
                    }
                }
            }

            for (int i = m_CacheRemoveUnscaledTimerList.Count - 1; i >= 0; i--)
            {
                Timer timer = m_UnscaledTimerList[m_CacheRemoveUnscaledTimerList[i]];
                m_UnscaledTimerList.RemoveAt(m_CacheRemoveUnscaledTimerList[i]);
                m_CacheRemoveUnscaledTimerList.RemoveAt(i);
                ReferencePool.Release(timer);
            }

            if (isLoopCall)
            {
                LoopCallUnscaledInBadFrame();
            }
        }
    }
}
