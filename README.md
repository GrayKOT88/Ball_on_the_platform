# Ball_on_the_platform
A simple game was taken to which some patterns were applied to the code to visually show the code before and after the changes.
# Реализация архитектуры и паттернов на практике. C#. Unity.
Для практики взял примитивную игру. В папке 'Old Scripts' находится изначальный код, а в 'New Scripts' изменённый код.

Если кратко о том что применил в коде:
### 1.Инъекция зависимостей (DI):
 - Использование Zenject для инъекции зависимостей.
### 2.Паттерны проектирования:
Command Pattern; Object Pool; MVC для UI; Observer Pattern; Event Bus.
### 3.Чистота кода:
 - Код структурирован, методы компактные и выполняют одну задачу.
 - Использование ScriptableObject (GameSettings) для настройки параметров игры.
### 4.Дополнительные улучшения:
 - Анимация кнопки (StartButton) с помощью DOTween
 - Очистка подписок (EventBus.ClearAllSubscriptions()) при перезагрузке сцены
 
