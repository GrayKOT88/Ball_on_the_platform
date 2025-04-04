using System.Collections.Generic;
using System;

namespace NewScript 
{
    public static class EventBus
    {
        private static readonly Dictionary<Type, List<Action<GameEvent>>> _subscribers = new();
        
        public static void Subscribe<T>(Action<T> handler) where T : GameEvent // �������� �� ������� ���� T
        {
            Type eventType = typeof(T);
            if (!_subscribers.ContainsKey(eventType))
            {
                _subscribers[eventType] = new List<Action<GameEvent>>();
            }
            
            Action<GameEvent> convertedHandler = (e) => handler((T)e); // ������������ Action<T> � Action<GameEvent>
            _subscribers[eventType].Add(convertedHandler);
        }
        
        public static void Unsubscribe<T>(Action<T> handler) where T : GameEvent // ������� �� ������� ���� T
        {
            Type eventType = typeof(T);
            if (_subscribers.TryGetValue(eventType, out var handlers))
            {
                Action<GameEvent> convertedHandler = (e) => handler((T)e);
                handlers.Remove(convertedHandler);
            }
        }
        
        public static void Publish<T>(T eventData) where T : GameEvent // ���������� �������
        {
            Type eventType = typeof(T);
            if (_subscribers.TryGetValue(eventType, out var handlers))
            {
                foreach (var handler in handlers)
                {
                    handler.Invoke(eventData);
                }
            }
        }

        public static void ClearAllSubscriptions() // ������� ��� ��������
        {
            _subscribers.Clear();
        }
    }
}