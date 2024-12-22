//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;

namespace GameFramework.Event
{
    /// <summary>
    /// 事件管理器。
    /// </summary>
    internal sealed class EventManager : GameFrameworkModule, IEventManager
    {
        private readonly EventPool m_EventPool;

        /// <summary>
        /// 初始化事件管理器的新实例。
        /// </summary>
        public EventManager()
        {
            m_EventPool = new EventPool();
        }

        /// <summary>
        /// 事件管理器轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        internal override void Update(float elapseSeconds, float realElapseSeconds)
        {
            m_EventPool.Update(elapseSeconds, realElapseSeconds);
        }

        /// <summary>
        /// 关闭并清理事件管理器。
        /// </summary>
        internal override void Shutdown()
        {
            m_EventPool.Shutdown();
        }

        /// <summary>
        /// 订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型编号。</param>
        /// <param name="handler">要订阅的事件处理函数。</param>
        /// <returns>是否订阅成功。</returns>
        public bool Subscribe(int eventType, GameFrameworkAction handler)
        {
            return m_EventPool.Subscribe(eventType, handler);
        }

        /// <summary>
        /// 订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">要订阅的事件处理函数。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <returns>是否订阅成功。</returns>
        public bool Subscribe<TArg1>(int eventType, GameFrameworkAction<TArg1> handler)
        {
            return m_EventPool.Subscribe(eventType, handler);
        }

        /// <summary>
        /// 订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">要订阅的事件处理函数。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数1类型。</typeparam>
        /// <returns>是否订阅成功。</returns>
        public bool Subscribe<TArg1, TArg2>(int eventType, GameFrameworkAction<TArg1, TArg2> handler)
        {
            return m_EventPool.Subscribe(eventType, handler);
        }

        /// <summary>
        /// 订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">要订阅的事件处理函数。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        /// <typeparam name="TArg3">事件参数3类型。</typeparam>
        /// <returns>是否订阅成功。</returns>
        public bool Subscribe<TArg1, TArg2, TArg3>(int eventType, GameFrameworkAction<TArg1, TArg2, TArg3> handler)
        {
            return m_EventPool.Subscribe(eventType, handler);
        }

        /// <summary>
        /// 订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">要订阅的事件处理函数。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        /// <typeparam name="TArg3">事件参数3类型。</typeparam>
        /// <typeparam name="TArg4">事件参数4类型。</typeparam>
        /// <returns>是否订阅成功。</returns>
        public bool Subscribe<TArg1, TArg2, TArg3, TArg4>(int eventType,
            GameFrameworkAction<TArg1, TArg2, TArg3, TArg4> handler)
        {
            return m_EventPool.Subscribe(eventType, handler);
        }

        /// <summary>
        /// 订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">要订阅的事件处理函数。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        /// <typeparam name="TArg3">事件参数3类型。</typeparam>
        /// <typeparam name="TArg4">事件参数4类型。</typeparam>
        /// <typeparam name="TArg5">事件参数5类型。</typeparam>
        /// <returns>是否订阅成功。</returns>
        public bool Subscribe<TArg1, TArg2, TArg3, TArg4, TArg5>(int eventType,
            GameFrameworkAction<TArg1, TArg2, TArg3, TArg4, TArg5> handler)
        {
            return m_EventPool.Subscribe(eventType, handler);
        }

        /// <summary>
        /// 订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">要订阅的事件处理函数。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        /// <typeparam name="TArg3">事件参数3类型。</typeparam>
        /// <typeparam name="TArg4">事件参数4类型。</typeparam>
        /// <typeparam name="TArg5">事件参数5类型。</typeparam>
        /// <typeparam name="TArg6">事件参数6类型。</typeparam>
        /// <returns>是否订阅成功。</returns>
        public bool Subscribe<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(int eventType,
            GameFrameworkAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> handler)
        {
            return m_EventPool.Subscribe(eventType, handler);
        }

        /// <summary>
        /// 取消订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">要取消订阅的事件处理函数。</param>
        /// <returns>是否订阅成功。</returns>
        public void Unsubscribe(int eventType, GameFrameworkAction handler)
        {
            m_EventPool.Unsubscribe(eventType, handler);
        }

        /// <summary>
        /// 取消订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">事件处理回调。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <returns>是否订阅成功。</returns>
        public void Unsubscribe<TArg1>(int eventType, GameFrameworkAction<TArg1> handler)
        {
            m_EventPool.Unsubscribe(eventType, handler);
        }

        /// <summary>
        /// 取消订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">事件处理回调。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数1类型。</typeparam>
        /// <returns>是否订阅成功。</returns>
        public void Unsubscribe<TArg1, TArg2>(int eventType, GameFrameworkAction<TArg1, TArg2> handler)
        {
            m_EventPool.Unsubscribe(eventType, handler);
        }

        /// <summary>
        /// 取消订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">事件处理回调。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        /// <typeparam name="TArg3">事件参数3类型。</typeparam>
        /// <returns>是否订阅成功。</returns>
        public void Unsubscribe<TArg1, TArg2, TArg3>(int eventType, GameFrameworkAction<TArg1, TArg2, TArg3> handler)
        {
            m_EventPool.Unsubscribe(eventType, handler);
        }

        /// <summary>
        /// 取消订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">事件处理回调。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        /// <typeparam name="TArg3">事件参数3类型。</typeparam>
        /// <typeparam name="TArg4">事件参数4类型。</typeparam>
        /// <returns>是否订阅成功。</returns>
        public void Unsubscribe<TArg1, TArg2, TArg3, TArg4>(int eventType,
            GameFrameworkAction<TArg1, TArg2, TArg3, TArg4> handler)
        {
            m_EventPool.Unsubscribe(eventType, handler);
        }

        /// <summary>
        /// 取消订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">事件处理回调。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        /// <typeparam name="TArg3">事件参数3类型。</typeparam>
        /// <typeparam name="TArg4">事件参数4类型。</typeparam>
        /// <typeparam name="TArg5">事件参数5类型。</typeparam>
        /// <returns>是否订阅成功。</returns>
        public void Unsubscribe<TArg1, TArg2, TArg3, TArg4, TArg5>(int eventType,
            GameFrameworkAction<TArg1, TArg2, TArg3, TArg4, TArg5> handler)
        {
            m_EventPool.Unsubscribe(eventType, handler);
        }

        /// <summary>
        /// 取消订阅事件处理函数。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="handler">事件处理回调。</param>
        /// <typeparam name="TArg1">事件参数1类型。</typeparam>
        /// <typeparam name="TArg2">事件参数2类型。</typeparam>
        /// <typeparam name="TArg3">事件参数3类型。</typeparam>
        /// <typeparam name="TArg4">事件参数4类型。</typeparam>
        /// <typeparam name="TArg5">事件参数5类型。</typeparam>
        /// <typeparam name="TArg6">事件参数6类型。</typeparam>
        /// <returns>是否订阅成功。</returns>
        public void Unsubscribe<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(int eventType,
            GameFrameworkAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> handler)
        {
            m_EventPool.Unsubscribe(eventType, handler);
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        public void FireNow(int eventType)
        {
            m_EventPool.FireNow(eventType);
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="arg1">事件参数1类型。</param>
        public void FireNow<TArg1>(int eventType, TArg1 arg1)
        {
            m_EventPool.FireNow(eventType,arg1);
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="arg1">事件参数1类型。</param>
        /// <param name="arg2">事件参数2类型。</param>
        public void FireNow<TArg1, TArg2>(int eventType, TArg1 arg1, TArg2 arg2)
        {
            m_EventPool.FireNow(eventType,arg1, arg2);
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="arg1">事件参数1类型。</param>
        /// <param name="arg2">事件参数2类型。</param>
        /// <param name="arg3">事件参数3类型。</param>
        public void FireNow<TArg1, TArg2, TArg3>(int eventType, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            m_EventPool.FireNow(eventType,arg1, arg2, arg3);
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="arg1">事件参数1类型。</param>
        /// <param name="arg2">事件参数2类型。</param>
        /// <param name="arg3">事件参数3类型。</param>
        /// <param name="arg4">事件参数4类型。</param>
        public void FireNow<TArg1, TArg2, TArg3, TArg4>(int eventType, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            m_EventPool.FireNow(eventType,arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="arg1">事件参数1类型。</param>
        /// <param name="arg2">事件参数2类型。</param>
        /// <param name="arg3">事件参数3类型。</param>
        /// <param name="arg4">事件参数4类型。</param>
        /// <param name="arg5">事件参数5类型。</param>
        public void FireNow<TArg1, TArg2, TArg3, TArg4, TArg5>(int eventType, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4,
            TArg5 arg5)
        {
            m_EventPool.FireNow(eventType,arg1, arg2, arg3, arg4, arg5);
        }

        /// <summary>
        /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。。
        /// </summary>
        /// <param name="eventType">事件类型。</param>
        /// <param name="arg1">事件参数1类型。</param>
        /// <param name="arg2">事件参数2类型。</param>
        /// <param name="arg3">事件参数3类型。</param>
        /// <param name="arg4">事件参数4类型。</param>
        /// <param name="arg5">事件参数5类型。</param>
        /// <param name="arg6">事件参数6类型。</param>
        public void FireNow<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(int eventType, TArg1 arg1, TArg2 arg2, TArg3 arg3,
            TArg4 arg4, TArg5 arg5, TArg6 arg6)
        {
            m_EventPool.FireNow(eventType,arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }
}
