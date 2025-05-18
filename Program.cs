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

Team new_building = new Team
{
    _builders = new List<Builder>
    {
        new Builder { _name = "Builder 1", _strength = 1 },
        new Builder { _name = "Builder 2", _strength = 2 },
        new Builder { _name = "Builder 3", _strength = 3 },
        new Builder { _name = "Builder 4", _strength = 4 }
    },

    _leader = new Team_Leader { _name = "Team Leader" },

    _house = new House()
};

while(new_building.Build(1) != false)
{
    WriteLine("\n\nBuilder with strength 1 been sent to build the house.");
}

new_building.Report();

public interface IPart
{
    string _name { get; set; }
    int _time { get; set; }
    bool _isdone { get; set; }
}

public interface IWorker
{
    string _name { get; }
}

public class Basement : IPart
{
    public string _name { set; get; }
    public int _time { set; get; }
    public bool _isdone { set; get; } = false;
}
public class Window : IPart
{
    public string _name { set; get; }
    public int _time { set; get; }
    public bool _isdone { set; get; } = false;
}
public class Wall : IPart
{
    public string _name { set; get; }
    public int _time { set; get; }
    public bool _isdone { set; get; } = false;
}
public class Roof : IPart
{
    public string _name { set; get; }
    public int _time { set; get; }
    public bool _isdone { set; get; } = false;
}
public class Door : IPart
{
    public string _name { set; get; }
    public int _time { set; get; }
    public bool _isdone { set; get; } = false;
}

public class Builder : IWorker
{
    public string _name { set; get; }
    public int _strength { set; get; }
}
public class Team_Leader : IWorker
{
    public string _name { set; get; }
}

public class Team
{
    public List<Builder> _builders { set; get; }
    public Team_Leader _leader { set; get; }
    public House _house {  set; get; }

    public bool Build(int req_str)
    {
        for (int i = 0; i < _house.parts.Length; i++) 
        {
            if (_house.parts[i]._isdone == false)
            {
                while (_house.parts[i]._time > 0)
                {
                    WriteLine($"\nBuilder {_builders[req_str - 1]._name} is building the object {_house.parts[i]._name}..");

                    _house.parts[i]._time -= _builders[req_str - 1]._strength;
                }

                _house.parts[i]._isdone = true;

                return true;
            }
        }

        WriteLine("\nKaloo kalay no work today!");

        return false;
    }

    public void Report()
    {
        WriteLine($"\n\n{_leader._name}'s report says:\n");
        for (int i = 0; i < _house.parts.Length; i++)
        {
            if (_house.parts[i]._isdone == true)
            {
                WriteLine($"\nObject {_house.parts[i]._name} is done!");
            }
            else
            {
                WriteLine($"\nObject {_house.parts[i]._name} isn't done yet.");
            }
        }
    }
}

public class House
{
    public IPart[] parts =
    {
        new Basement{_name = "Basement", _time = 5},
        new Wall{_name = "Wall 1", _time = 4},
        new Wall{_name = "Wall 2", _time = 4},
        new Wall{_name = "Wall 3", _time = 4},
        new Wall{_name = "Wall 4", _time = 4},
        new Door{_name = "Door", _time = 3},
        new Window{_name = "Window 1", _time = 2},
        new Window{_name = "Window 2", _time = 2},
        new Window{_name = "Window 3", _time = 2},
        new Window{_name = "Window 4", _time = 2},
        new Roof{_name = "Roof", _time = 6}
    };
}