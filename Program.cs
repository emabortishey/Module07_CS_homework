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

// переменная бригады строителей с инициализацией

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

// пока дом не закончен, посылается рабочий 
// с силой 1 и выводится сообщение о отправке на обьект
while(new_building.Build(1) != false)
{
    WriteLine("\n\nBuilder with strength 1 been sent to build the house.");
}

// по завершению стройки составляется отчёт

new_building.Report();

// ИНТЕРФЕЙСЫ

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

// ЧАСТИ ДОМА

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

// РАБОЧИЕ

public class Builder : IWorker
{
    public string _name { set; get; }
    public int _strength { set; get; }
}
public class Team_Leader : IWorker
{
    public string _name { set; get; }
}

// КЛАСС БРИГАДЫ РАБОЧИХ

public class Team
{
    // контейнер рабочих
    public List<Builder> _builders { set; get; }
    // бригадир
    public Team_Leader _leader { set; get; }
    // дом необходимый к постройке
    public House _house {  set; get; }

    // метод стройки дома
    public bool Build(int req_str)
    {
        // пробегаемся по массиву в классе дома
        for (int i = 0; i < _house.parts.Length; i++) 
        {
            // если текущий парт ещё не построен
            // переходим в условие
            if (_house.parts[i]._isdone == false)
            {
                // пока время необходимое для постройки
                // не истекло, рабочий продолжает пахать
                while (_house.parts[i]._time > 0)
                {
                    // вывод о том, какой рабочий и какую часть делает
                    WriteLine($"\nBuilder {_builders[req_str - 1]._name} is building the object {_house.parts[i]._name}..");

                    // отнимаем от времени парта сделанную часть
                    _house.parts[i]._time -= _builders[req_str - 1]._strength;
                }

                // по окончанию постройки ставим готовность на тру
                _house.parts[i]._isdone = true;

                // возвращение тру, извещающего о выполненной работе
                return true;
            }
        }

        // вывод радостного крика рабочего если
        // вся постройка уже завершена но
        // его зачем-то послали на объект
        WriteLine("\nKaloo kalay no work today!");

        // возвращение фолс если работа не потребовалась
        return false;
    }

    // метод создания отчёта
    public void Report()
    {
        // переменная для отлова значения готовности
        bool if_smt_not_ready = false;
        // вывод имени лидера бригады 
        WriteLine($"\n\n{_leader._name}'s report says:\n");
        //пробег по всем партам дома
        for (int i = 0; i < _house.parts.Length; i++)
        {
            // если готовность парта на тру
            // то это выводится в консоль и наоборот
            if (_house.parts[i]._isdone == true)
            {
                WriteLine($"\nObject {_house.parts[i]._name} is done!");
            }
            else
            {
                WriteLine($"\nObject {_house.parts[i]._name} isn't done yet.");

                // если всё-таки какая-то часть не готова
                // переменной присваивается тру
                if_smt_not_ready = true;
            }
        }

        // вывод домика из символов и поздравления по завершению
        // в случае если все части дома успешно построены к моменту отчёта
        if( !if_smt_not_ready )
        {
            WriteLine("\n\n        `'::.\r\n    _________H ,%%&%,\r\n   /\\     _   \\%&&%%&%\r\n  /  \\___/^\\___\\%&%%&&\r\n  |  | []   [] |%\\Y&%'\r\n  |  |   .-.   | ||  \r\n~~@._|@@_|||_@@|~||~~~~~~~~~~~~~\r\n     `\"\"\") )\"\"\"`");

            WriteLine("\n\nCongrats! Your house is ready!");
        }
    }
}

// КЛАСС ДОМА

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