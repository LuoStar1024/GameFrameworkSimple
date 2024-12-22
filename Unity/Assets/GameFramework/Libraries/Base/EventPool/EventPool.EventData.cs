using System;
using System.Collections.Generic;

namespace GameFramework
{
    internal sealed partial class EventPool
    {
        /// <summary>
        /// 事件结点。
        /// </summary>
        private sealed class EventData : IReference
        {
            private int m_ID = 0;
            private readonly List<Delegate> m_ExistList = new List<Delegate>();
            private readonly List<Delegate> m_AddList = new List<Delegate>();
            private readonly List<Delegate> m_DeleteList = new List<Delegate>();
            private bool m_IsExecute = false;
            private bool m_IsDirty = false;

            /// <summary>
            /// 订阅事件处理委托。
            /// </summary>
            /// <param name="handler">事件处理回调。</param>
            /// <returns>是否添加回调成功。</returns>
            internal bool Subscribe(Delegate handler)
            {
                if (m_ExistList.Contains(handler))
                {
                    GameFrameworkLog.Fatal("Repeated Add Handler");
                    return false;
                }

                if (m_IsExecute)
                {
                    m_IsDirty = true;
                    m_AddList.Add(handler);
                }
                else
                {
                    m_ExistList.Add(handler);
                }

                return true;
            }

            /// <summary>
            /// 取消订阅事件处理委托。
            /// </summary>
            /// <param name="handler">事件处理回调。</param>
            internal void Unsubscribe(Delegate handler)
            {
                if (m_IsExecute)
                {
                    m_IsDirty = true;
                    m_DeleteList.Add(handler);
                }
                else
                {
                    if (!m_ExistList.Remove(handler))
                    {
                        GameFrameworkLog.Fatal("Delete handle failed, not exist, EventId: {0}",
                            EventRuntimeId.ToString(m_ID));
                    }
                }
            }

            /// <summary>
            /// 检测脏数据修正。稍后移除或增加数据
            /// </summary>
            private void CheckModify()
            {
                m_IsExecute = false;
                if (m_IsDirty)
                {
                    for (int i = 0; i < m_AddList.Count; i++)
                    {
                        m_ExistList.Add(m_AddList[i]);
                    }

                    m_AddList.Clear();

                    for (int i = 0; i < m_DeleteList.Count; i++)
                    {
                        m_ExistList.Remove(m_DeleteList[i]);
                    }

                    m_DeleteList.Clear();
                }
            }

            /// <summary>
            /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
            /// </summary>
            public void FireNow()
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is GameFrameworkAction action)
                    {
                        action();
                    }
                }

                CheckModify();
            }

            /// <summary>
            /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
            /// </summary>
            /// <param name="arg1">事件参数1。</param>
            /// <typeparam name="TArg1">事件参数1类型。</typeparam>
            public void FireNow<TArg1>(TArg1 arg1)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is GameFrameworkAction<TArg1> action)
                    {
                        action(arg1);
                    }
                }

                CheckModify();
            }

            /// <summary>
            /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
            /// </summary>
            /// <param name="arg1">事件参数1。</param>
            /// <param name="arg2">事件参数2。</param>
            /// <typeparam name="TArg1">事件参数1类型。</typeparam>
            /// <typeparam name="TArg2">事件参数2类型。</typeparam>
            public void FireNow<TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is GameFrameworkAction<TArg1, TArg2> action)
                    {
                        action(arg1, arg2);
                    }
                }

                CheckModify();
            }

            /// <summary>
            /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
            /// </summary>
            /// <param name="arg1">事件参数1。</param>
            /// <param name="arg2">事件参数2。</param>
            /// <param name="arg3">事件参数3。</param>
            /// <typeparam name="TArg1">事件参数1类型。</typeparam>
            /// <typeparam name="TArg2">事件参数2类型。</typeparam>
            /// <typeparam name="TArg3">事件参数3类型。</typeparam>
            public void FireNow<TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is GameFrameworkAction<TArg1, TArg2, TArg3> action)
                    {
                        action(arg1, arg2, arg3);
                    }
                }

                CheckModify();
            }

            /// <summary>
            /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
            /// </summary>
            /// <param name="arg1">事件参数1。</param>
            /// <param name="arg2">事件参数2。</param>
            /// <param name="arg3">事件参数3。</param>
            /// <param name="arg4">事件参数4。</param>
            /// <typeparam name="TArg1">事件参数1类型。</typeparam>
            /// <typeparam name="TArg2">事件参数2类型。</typeparam>
            /// <typeparam name="TArg3">事件参数3类型。</typeparam>
            /// <typeparam name="TArg4">事件参数4类型。</typeparam>
            public void FireNow<TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is GameFrameworkAction<TArg1, TArg2, TArg3, TArg4> action)
                    {
                        action(arg1, arg2, arg3, arg4);
                    }
                }

                CheckModify();
            }

            /// <summary>
            /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
            /// </summary>
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
            public void FireNow<TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4,
                TArg5 arg5)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is GameFrameworkAction<TArg1, TArg2, TArg3, TArg4, TArg5> action)
                    {
                        action(arg1, arg2, arg3, arg4, arg5);
                    }
                }

                CheckModify();
            }

            /// <summary>
            /// 抛出事件立即模式，这个操作不是线程安全的，事件会立刻分发。
            /// </summary>
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
            public void FireNow<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg1 arg1, TArg2 arg2, TArg3 arg3,
                TArg4 arg4, TArg5 arg5, TArg6 arg6)
            {
                m_IsExecute = true;
                for (var i = 0; i < m_ExistList.Count; i++)
                {
                    var d = m_ExistList[i];
                    if (d is GameFrameworkAction<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> action)
                    {
                        action(arg1, arg2, arg3, arg4, arg5, arg6);
                    }
                }

                CheckModify();
            }

            public static EventData Create(int eventType)
            {
                EventData eventData = ReferencePool.Acquire<EventData>();
                eventData.m_ID = eventType;
                return eventData;
            }

            public void Clear()
            {
                m_ID = 0;
                m_ExistList.Clear();
                m_AddList.Clear();
                m_DeleteList.Clear();
                m_IsExecute = false;
                m_IsDirty = false;
            }
        }
    }
}