
//Jose Rosales - What Time is It 

//enter hour
Console.WriteLine("Please, enter hour");
int hour = Convert.ToInt16(Console.ReadLine());

//enter minutes
Console.WriteLine("Please, enter minutes");
int minute = Convert.ToInt16(Console.ReadLine());

//Get The description of hour
static string getHourDesc(int hour, int minute)
{
    if (minute > 30)
    {
        hour = (hour + 1) % 24;
    }

    if (hour > 12) hour -= 12;
     
    var hourDesc = new Dictionary<int, string>()
    {
        {0,"midnight"},
        {1,"one"},
        {2,"two"},
        {3,"three"},
        {4,"four"},
        {5,"five"},
        {6,"six"},
        {7,"seven"},
        {8,"eight"},
        {9,"nine"},
        {10,"ten"},
        {11,"eleven"},
        {12,"noon"},
    };

    return $"{hourDesc[hour]}";
}
//Get The description of minutes
static string getMinDesc(int minute, int hour)
{
    if (minute == 0) return " o'clock";
    if (minute <= 30)
    {
        return minute switch
        {
            15 => "quarter past",
            30 => "half past",
            _ when minute == 1 => $"{minute} minute past",
            _ =>  $"{minute} minutes past"
        };
    }
    else
    {
        minute = 60 - minute;

        return minute switch
        {

            15 => "quarter to",
            _ when minute == 1 => $"{minute} minute past",
            _ => $"{minute} minutes to"
        };

            
    }


}
//merge both hour and minutes
static string GetAll(int hour, int minute)
{
    string hourTextDesc = getHourDesc(hour, minute);

    string minuteTextDesc = getMinDesc(minute, hour);

    // 0:00 is midnight
    if(hour == 0 && minute == 0) return "midnight";
    // 12:00 is noon
    if (hour == 12 && minute == 0) return "noon";



    if (minuteTextDesc.Trim().Contains("o'clock")) return hourTextDesc +
            " " + minuteTextDesc; 

    return minuteTextDesc + " "+ hourTextDesc;
}


Console.WriteLine("   " + GetAll(hour, minute));

Console.WriteLine("Press any key to continue...");
Console.ReadKey();