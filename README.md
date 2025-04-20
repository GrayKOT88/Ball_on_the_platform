# Ball_on_the_platform
A simple game was taken to which some patterns were applied to the code to visually show the code before and after the changes.
# Реализация архитектуры и паттернов на практике. C#. Unity.
Для практики взял примитивную игру. В папке 'Old Scripts' находится изначальный код, а в 'New Scripts' изменённый код.

Если кратко о том что применил в коде:
 - Код структурирован, методы компактные.
 - Использование Событий и Интерфейсов.
 - Использование ScriptableObject (GameSettings) для настройки параметров игры.
 - Использование Dependency Injection (через Zenject) для управления зависимостями.
 - Разделение логики на MVC (Model-View-Controller) для таймера и счёта.
 - Применение Command Pattern (ApplyForceCommand) для инкапсуляции действий.
 - Event Bus для глобальных событий (EnemyDestroyedEvent, PowerupCollectedEvent).
 - Пул объектов (EnemyPool, PowerupPool) для переиспользования экземпляров и снижения нагрузки. 
 - Анимация кнопок через DOTween.
 - Очистка подписок (EventBus.ClearAllSubscriptions()) при перезагрузке сцены.
 - Добовление плагина PluginYG, и реализация «Лидерборда».
 
### Итоговая оценка: 8.5/10 (оценка дана нейросетью через которую пропустил весь этот код)
Это отличный код для небольшой игры, демонстрирующий хорошие практики Unity-разработки. Он чистый, расширяемый и оптимизированный. Небольшие улучшения могут сделать его ещё лучше, но текущая реализация уже очень сильная.
