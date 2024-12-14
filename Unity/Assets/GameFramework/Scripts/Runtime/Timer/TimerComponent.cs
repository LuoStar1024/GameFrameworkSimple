using GameFramework;
using GameFramework.Timer;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    /// <summary>
    /// 对象池组件。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Timer")]
    public sealed class TimerComponent : GameFrameworkComponent
    {
        private ITimerManager m_TimerManager = null;

        protected override void Awake()
        {
            base.Awake();

            m_TimerManager = GameFrameworkEntry.GetModule<ITimerManager>();
            if (m_TimerManager == null)
            {
                Log.Fatal("Timer manager is invalid.");
                return;
            }
        }

        private void Start()
        {
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
            return m_TimerManager.AddTimer(time, callback, repeatCount, isUnscaled, args);
        }

        /// <summary>
        /// 暂停计时器。
        /// </summary>
        /// <param name="timerId">计时器Id。</param>
        public void StopTimer(int timerId)
        {
            m_TimerManager.StopTimer(timerId);
        }

        /// <summary>
        /// 恢复计时器。
        /// </summary>
        /// <param name="timerId">计时器Id。</param>
        public void ResumeTimer(int timerId)
        {
            m_TimerManager.ResumeTimer(timerId);
        }

        /// <summary>
        /// 计时器是否在运行中。
        /// </summary>
        /// <param name="timerId">计时器Id。</param>
        /// <returns>否在运行中。</returns>
        public bool IsRunning(int timerId)
        {
            return m_TimerManager.IsRunning(timerId);
        }

        /// <summary>
        /// 获得计时器剩余时间。
        /// </summary>
        public float GetLeftTime(int timerId)
        {
            return m_TimerManager.GetLeftTime(timerId);
        }

        /// <summary>
        /// 重置计时器,恢复到开始状态。
        /// </summary>
        public void Restart(int timerId)
        {
            m_TimerManager.Restart(timerId);
        }

        /// <summary>
        /// 重置计时器。
        /// </summary>
        /// <param name="timerId">定时器ID。</param>
        /// <param name="time">时间间隔。</param>
        /// <param name="callback">回调。</param>
        /// <param name="repeatCount">调用次数，小于等于0为无限。</param>
        /// <param name="isUnscaled">是否不受时间缩放影响。</param>
        public void Reset(int timerId, float time, GameFrameworkActionArgs callback, int repeatCount = 1, bool isUnscaled = false)
        {
            m_TimerManager.Reset(timerId, time, callback, repeatCount, isUnscaled);
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
            m_TimerManager.Reset(timerId, time, repeatCount, isUnscaled);
        }

        /// <summary>
        /// 移除计时器。
        /// </summary>
        /// <param name="timerId">计时器Id。</param>
        public void RemoveTimer(int timerId)
        {
            m_TimerManager.RemoveTimer(timerId);
        }

        /// <summary>
        /// 移除所有计时器。
        /// </summary>
        public void RemoveAllTimer()
        {
            m_TimerManager.RemoveAllTimer();
        }
    }
}
