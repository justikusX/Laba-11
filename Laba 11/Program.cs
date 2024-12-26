using System;

class Meeting
{
    protected string eventName;
    protected int n1; // число ораторов
    protected int n2; // число участников

    public Meeting(string name, int speakers, int participants)
    {
        eventName = name;
        n1 = speakers;
        n2 = participants;
    }

    public virtual double Q()
    {
        return (double)n1 / n2;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Событие: {eventName}, Ораторы: {n1}, Участники: {n2}, Качество: {Q()}");
    }
}

class SpecialMeeting : Meeting
{
    private int P; // число групп ораторов

    public SpecialMeeting(string name, int speakers, int participants, int groups)
        : base(name, speakers, participants)
    {
        P = groups;
    }

    public override double Q()
    {
        return base.Q() + (double)P / n2;
    }

    public new void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Дополнительное поле P: {P}, Качество (с учетом P): {Q()}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Meeting meeting = new Meeting("Общее собрание", 5, 20);
        meeting.DisplayInfo();

        SpecialMeeting specialMeeting = new SpecialMeeting("Специальное собрание", 4, 15, 2);
        specialMeeting.DisplayInfo();
    }
}