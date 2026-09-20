# 🎮 QuizGame (In Development)

**QuizGame** — это консольная игра-викторина на языке C#, в которой игроки могут отвечать на вопросы, соревноваться и проверять свои знания. Проект находится на этапе активной разработки.

---

## 🖼️ Скриншоты и демонстрация
*Как выглядит консольное приложение на данный момент:*

<img width="900" height="480" alt="Main_Menu" src="https://github.com/user-attachments/assets/8e44d96c-4b0e-4699-a16c-2caf217aa269" />

*Рис 1. Текущая реализация стартового консольного меню.*

---

## 🛠️ Текущий статус разработки
На данный момент заложена архитектурная основа проекта и реализован текстовый каркас:

* **Интерфейс:** Создано консольное главное меню с текстовой навигацией.
* **Core-архитектура:** Написаны базовые классы для управления сущностями (вопросы `Card` и `TextCard`, игроки `Player`).

---

## 💾 Работа с файлами (TXT)
Вся динамическая информация в игре вынесена за пределы кода:
* **Вопросы:** Хранятся в специальном текстовом формате во внешних `.txt` файлах. Это позволяет легко редактировать и добавлять новые викторины без пересборки игры.
* **Настройки:** Параметры игры (например, время на ответ, количество вопросов в сессии, цветовая палитра консоли) также считываются из конфигурационного `.txt` файла при старте приложения.

---

## 🗺️ Дорожная карта (Roadmap)

- [x] Разработать структуру классов и текстовое меню.
- [ ] Настроить парсинг вопросов и конфигурации из `.txt` файлов.
- [ ] **Одиночный режим (Solo):** Логика последовательного вывода вопросов, валидация ответов и подсчет финальных очков.
- [ ] **Локальный мультиплеер (В планах):** Режим игры для нескольких игроков за одним компьютером (поочередные ходы).
- [ ] **Стековый мультиплеер (В планах):** Полноценная сетевая игра по архитектуре Клиент-Сервер.

---

## 📊 Блок схемы и диограммы

### Диаграмма классов

```mermaid
classDiagram
    namespace Models {
        class Game {
            -List~Player~ players
            -List~Card~ cards
            +Run()
        }
        class GameMaster {
            -string name
            -bool isActive
        }
        class Player {
            -string name
            -int score
        }
        class Card {
            <<abstract>>
            -string name
            -int score
            -string answer
            -bool isPassed
        }
        class TextCard {
            -string text
        }
    }
    namespace UserInterface {
        class UI {
            +PrintMenu()
            +PrintSoloGame(Player player)
            -PrintCenter()
        }
    }
    namespace Services {
        class LoadCardService {
	        -cardFilePath
            +List~TextCard~ CardLoad()
        }
    }
    namespace Helpers{
	    class TXTHelper{
		    +bool TxTWrite(string filePath, string[] texts)
		    +string[] TxTRead(string filePath)
	    }
    }
    Game --> GameMaster
    Game --> Player
    Game --> Card
    Game --> UI
    Card <|-- TextCard
    Game ..> LoadCardService
    LoadCardService --> TextCard
    LoadCardService --> TXTHelper
```

### Блок-схема игрового цикла

```mermaid
flowchart TD
    Start([Запуск Program.cs])--> Init[Инициализация Game <br> и загрузка настроек консоли]
    Init --> Menu[/UI: Главное меню/]
    Menu --> GameMode[/Ввод: Выбор режима игры/]
    GameMode -- Одиночная игра --> GameOptionsUI[/UI: Отображение настроек одиночной сесии/]
    GameOptionsUI --> GameOptions[/Ввод: Изменение настроек сессии/]
    GameOptions --> ValidateOptions{Настройки валидны?}
    
    ValidateOptions -- Да --> SoloGame[Game: Запуск одиночной игры]
    ValidateOptions -- Нет --> GameOptions
    
    %% Начало цикла раунда
    SoloGame --> LoopStart{Есть карточки в колоде?}
    
    LoopStart -- Да --> ShowBoard[/UI: Отрисовка игрового поля со всеми карточками/]
    ShowBoard --> ChoiseCard[/Ввод: Выбор карточки/]
    ChoiseCard --> EventLoop{Состояние: Ожидание ввода <br> Таймер идет}
    
    %% Ветки ожидания
    EventLoop -- Ввод ответа --> Check{Game: Проверка ответа}
    EventLoop -- Время вышло --> Penalty[Вычитание очков игроку]
    
    %% Проверка ответа
    Check -- Верно --> AddPoints[Начисление очков игроку]
    Check -- Неверно --> Penalty
    
    %% Завершение хода
    AddPoints --> ReturnLoopGame[Возврат к выбору карточки]
    Penalty --> ReturnLoopGame
    
    %% Возврат на проверку колоды
    ReturnLoopGame --> LoopStart
    
    %% Конец игры
    LoopStart -- Нет --> ShowFinal[/UI: Окно финальных <br> результатов игры/]
    ShowFinal --> End([Завершение игры])

```
---
