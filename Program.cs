// See https://aka.ms/new-console-template for more information
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;

Console.WriteLine("Traffic Light Controller");
int timeout = 0;

var traffic = new Traffic(Light.Green, Light.Red);


while (true)
{

    ToggleLights(traffic);

}

void TimerMessage(int seconds)
{
    for (int i = seconds; i > 0; i--)
    {
        Console.Write("\r{0}  ", i);
        Thread.Sleep(1000);
    }
}

void LightMessage(Light light)
{
    switch(light)
    {
        case Light.Green:
            Console.ForegroundColor = ConsoleColor.Green; break;
        case Light.Red:
            Console.ForegroundColor = ConsoleColor.Red; break;
        case Light.Yellow:
            Console.ForegroundColor = ConsoleColor.Yellow; break;
        default:
            Console.ForegroundColor = ConsoleColor.White; break;
    }
    Console.Write(light.ToString());
    Console.ForegroundColor = ConsoleColor.White;
}

void ToggleLights(Traffic traffic)
{
    Console.Write("North South Light: ");
    LightMessage(traffic.NSLight);
    Console.Write(" East West Light: ");
    LightMessage(traffic.EWLight);
    Console.WriteLine();

    Console.Write("Light changing in ");
    if (traffic.NSLight == Light.Yellow || traffic.NSLight == Light.Yellow)
    {
        Console.WriteLine("5 seconds");
        TimerMessage(5);
    } else
    {
        Console.WriteLine("10 seconds");
        TimerMessage(10);
    }
    Console.WriteLine();
    //Check current direction, switch light
    if (traffic.NSLight == Light.Green && traffic.EWLight == Light.Red) //EW Red
    {
        //Console.WriteLine("setting North South to Yellow");
        traffic.NSLight = Light.Yellow;
        
    }
    else if (traffic.NSLight == Light.Yellow) //EW Red
    {
        //Console.WriteLine("setting North South to Red");
        traffic.NSLight = Light.Red;
        traffic.EWLight = Light.Green;

    }
    else if (traffic.NSLight == Light.Red && traffic.EWLight == Light.Yellow) 
    {
        //Console.WriteLine("setting North South to Green");
        traffic.NSLight = Light.Green;
        traffic.EWLight = Light.Red;
    }
    else if (traffic.NSLight == Light.Red && traffic.EWLight == Light.Green)
    {
        //Console.WriteLine("setting East West to Yellow");
        traffic.EWLight = Light.Yellow;
    }
}



//Check last direction and switch lights from green to yellow, then red
//green = 1 minute
//yellow = 10 seconds
//red = 1 minute (has to be the same as green unless variable based on direction

class Traffic
{
    public Traffic(Light nsLight,Light ewLight)
    {
        this.NSLight = nsLight;
        this.EWLight = ewLight;
    }
    public Light NSLight { get; set; }
    public Light EWLight { get; set; }

}

enum Direction
{
    North,
    South
}

enum Light
{
    Red,
    Yellow,
    Green
}