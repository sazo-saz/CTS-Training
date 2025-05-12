
using System;
public class Alarm
{
    public event EventHandler OnAlarm;
    public void TriggerAlarm()
    {
        Console.WriteLine("Triggering Alarm...");
        OnAlarm?.Invoke(this, EventArgs.Empty);
    }
}
class EventsExample
{
    static void Main()
    {
        var alarm = new Alarm();
        alarm.OnAlarm += AlarmHandler1;
        alarm.OnAlarm += AlarmHandler2;
        alarm.TriggerAlarm();
    }
    static void AlarmHandler1(object sender, EventArgs e)
    {
        Console.WriteLine("Handler 1: Alarm received!");
    }
    static void AlarmHandler2(object sender, EventArgs e)
    {
        Console.WriteLine("Handler 2: Logging the alarm...");
    }
}