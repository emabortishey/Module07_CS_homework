using static System.Console;

// ZADANIE 1

/*

. Реализовать программу “Строительство дома”
Реализовать:

• Классы

■ House (Дом), Basement (Фундамент), Walls (Стены),
Door (Дверь), Window (Окно), Roof (Крыша);
■ Team (Бригада строителей), Worker (Строитель),
TeamLeader (Бригадир).
• Интерфейсы
■ IWorker, IPart.

Все части дома должны реализовать интерфейс IPart
(Часть дома), для рабочих и бригадира предоставляется
базовый интерфейс IWorker (Рабочий).

Бригада строителей (Team) строит дом (House). Дом
состоит из фундамента (Basement), стен (Wall), окон
(Window), дверей (Door), крыши (Part).
Согласно проекту, в доме должно быть 1 фундамент,
4 стены, 1 дверь, 4 окна и 1 крыша.
Бригада начинает работу, и строители последовательно
“строят” дом, начиная с фундамента. Каждый строитель
не знает заранее, на чём завершился предыдущий этап
строительства, поэтому он “проверяет”, что уже построено и продолжает работу. Если в игру вступает бригадир
(TeamLeader), он не строит, а формирует отчёт, что уже
построено и какая часть работы выполнена.
В конечном итоге на консоль выводится сообщение, что
строительство дома завершено и отображается “рисунок
дома” (вариант отображения выбрать самостоятельно).

*/

public interface IPart
{
    string _name { get; }
    int _time { get; }
}

public interface IWorker
{
    string _name { get; }
}

public class Basement : IPart
{
    public string _name { set; get; }
    public int _time { set; get; }
}
public class Window : IPart
{
    public string _name { set; get; }
    public int _time { set; get; }
}
public class Wall : IPart
{
    public string _name { set; get; }
    public int _time { set; get; }
}
public class Roof : IPart
{
    public string _name { set; get; }
    public int _time { set; get; }
}
public class Door : IPart
{
    public string _name { set; get; }
    public int _time { set; get; }
}

public class Builder : IWorker
{
    public string _name { set; get; }
    public int _strength { set; get; }
}
public class Team_Leader : IWorker
{
    public string _name { set; get; }
    public int _strength { set; get; }
}

public class Team
{
    public Builder[] builders =
    {
        new Builder { _name = "Builder 1", _strength = 1 },
        new Builder { _name = "Builder 2", _strength = 2 },
        new Builder { _name = "Builder 3", _strength = 3 },
        new Builder { _name = "Builder 4", _strength = 4 }
    };
    public Team_Leader leader { set; get; }
}

public class House
{
    public Basement _base { set; get; }
    public Wall[] _walls { set; get; }
    public Window[] _windows { set; get; }
    public Door _door { set; get; }
    public Roof _roof { set; get; }
}