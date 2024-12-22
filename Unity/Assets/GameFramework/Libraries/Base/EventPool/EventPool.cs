using System;
using System.Collections.Generic;

namespace GameFramework
{
    /// <summary>
    /// 事件池。
    /// </summary>
    /// <typeparam name="T">事件类型。</typeparam>
    internal sealed partial class EventPool
    {
        /// <summary>
        /// 事件Table。
        /// </summary>
        private static readonly Dictionary<int, EventData> EventDict = new Dictionary<int, EventData>();

        /// <summary>
        /// 事件池轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        public void Update(float elapseSeconds, float realElapseSeconds)
        {
        }

        /// <summary>
        /// 关闭并清理事件池。
        /// </summary>
        public void Shutdown()
        {
            EventDict.Clear();
        }
        
        #region 事件管理接口

        /// <summary>
        /// 订阅事件处理委托。
        /// </summary>
        /// <param name="id">事件类型。</param>
        /// <param name="handler">事件处理委托。</param>
        /// <returns>是否添加成功。</returns>
        public bool Subscribe(int id, Delegate handler)
        {
            if (!EventDict.TryGetValue(id, out var data))
            {
                data = EventData.Create(id);
                EventDict.Add(id, data);
            }

            return data.Subscribe(handler);
        }

        /// <summary>
        /// 取消订阅事件处理委托。
        /// </summary>
        /// <param name="id">事件类型。</param>
        /// <param name="handler">事件处理委托。</param>
        public void Unsubscribe(int id, Delegate handler)
        {
            if (EventDict.TryGetValue(id, out var data))
            {
                data.Unsubscribe(handler);
            }
        }

        #endregion

        #region 事件分发接口

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
        /// </summary>
        /// <param name="id">事件类型。</param>
        public void FireNow(int id)
        {
            if (EventDict.TryGetValue(id, out var d))
            {
                d.FireNow();
            }
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
        /// </summary>
        /// <param name="id">事件类型。</param>
        /// <param name="arg1">事件参数1。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        public void FireNow<TArg1>(int id, TArg1 arg1)
        {
            if (EventDict.TryGetValue(id, out var d))
            {
                d.FireNow(arg1);
            }
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
        /// </summary>
        /// <param name="id">事件类型。</param>
        /// <param name="arg1">事件参数1。</param>
        /// <param name="arg2">事件参数2。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        public void FireNow<TArg1, TArg2>(int id, TArg1 arg1, TArg2 arg2)
        {
            if (EventDict.TryGetValue(id, out var d))
            {
                d.FireNow(arg1, arg2);
            }
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
        /// </summary>
        /// <param name="id">事件类型。</param>
        /// <param name="arg1">事件参数1。</param>
        /// <param name="arg2">事件参数2。</param>
        /// <param name="arg3">事件参数3。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        /// <typeparam name="TArg3">事件参数3类型。</typeparam>
        public void FireNow<TArg1, TArg2, TArg3>(int id, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            if (EventDict.TryGetValue(id, out var d))
            {
                d.FireNow(arg1, arg2, arg3);
            }
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
        /// </summary>
        /// <param name="id">事件类型。</param>
        /// <param name="arg1">事件参数1。</param>
        /// <param name="arg2">事件参数2。</param>
        /// <param name="arg3">事件参数3。</param>
        /// <param name="arg4">事件参数4。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        /// <typeparam name="TArg3">事件参数3类型。</typeparam>
        /// <typeparam name="TArg4">事件参数4类型。</typeparam>
        public void FireNow<TArg1, TArg2, TArg3, TArg4>(int id, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            if (EventDict.TryGetValue(id, out var d))
            {
                d.FireNow(arg1, arg2, arg3, arg4);
            }
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
        /// </summary>
        /// <param name="id">事件类型。</param>
        /// <param name="arg1">事件参数1。</param>
        /// <param name="arg2">事件参数2。</param>
        /// <param name="arg3">事件参数3。</param>
        /// <param name="arg4">事件参数4。</param>
        /// <param name="arg5">事件参数5。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        /// <typeparam name="TArg3">事件参数3类型。</typeparam>
        /// <typeparam name="TArg4">事件参数4类型。</typeparam>
        /// <typeparam name="TArg5">事件参数5类型。</typeparam>
        public void FireNow<TArg1, TArg2, TArg3, TArg4, TArg5>(int id, TArg1 arg1, TArg2 arg2, TArg3 arg3,
            TArg4 arg4, TArg5 arg5)
        {
            if (EventDict.TryGetValue(id, out var d))
            {
                d.FireNow(arg1, arg2, arg3, arg4, arg5);
            }
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
        /// </summary>
        /// <param name="id">事件类型。</param>
        /// <param name="arg1">事件参数1。</param>
        /// <param name="arg2">事件参数2。</param>
        /// <param name="arg3">事件参数3。</param>
        /// <param name="arg4">事件参数4。</param>
        /// <param name="arg5">事件参数5。</param>
        /// <param name="arg6">事件参数6。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        /// <typeparam name="TArg3">事件参数3类型。</typeparam>
        /// <typeparam name="TArg4">事件参数4类型。</typeparam>
        /// <typeparam name="TArg5">事件参数5类型。</typeparam>
        /// <typeparam name="TArg6">事件参数6类型。</typeparam>
        public void FireNow<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(int id, TArg1 arg1, TArg2 arg2, TArg3 arg3,
            TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            if (EventDict.TryGetValue(id, out var d))
            {
                d.FireNow(arg1, arg2, arg3, arg4, arg5, arg6);
            }
        }

        #endregion
    }
}
