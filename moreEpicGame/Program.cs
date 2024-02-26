//HP depends on name length, hit depends on HP and random
//

string folderPath = @"D:\OneDrive - Tallinna Tehnikakõrgkool\Programmeerimine\data";        //remove double slashes, add @, *add slash to end unless using Path.Combine()
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));        //reads data as array entries; File.ReadAllLines(folderPath+heroFile) also works
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));   //but Path.Combine is smarter, takes OS into account
string[] weapon = {"wand", "fork", "apple", "Lego sword", "stone"};

string hero = GetRandomArrayValue(heroes);
string heroWeapon = GetRandomArrayValue(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrike = heroHP;        //fix this and villainStrikePath at this stage to handle while loop making heroHP<0, which is out of range for rnd.Next(0, characterHP) in Hit()
string villain = GetRandomArrayValue(villains);
string villainWeapon = GetRandomArrayValue(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrike = villainHP;      

Console.WriteLine($"{hero} [{heroHP}] is your only hope...{villain} [{villainHP}] is on the rise. A battle of {heroWeapon} versus {villainWeapon}!");

while (heroHP > 0 && villainHP > 0)         //use while activity end is unknown, will work until someone dies
{
    heroHP = heroHP - Hit(villain, villainStrike);
    villainHP = villainHP - Hit(hero, heroStrike);
}

Console.WriteLine($"{hero} HP: {heroHP}. {villain} HP: {villainHP}.");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day.");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Darkness prevails!");
}
else
{
    Console.WriteLine("Balance has been achieved.");
}

static string GetRandomArrayValue(string[] someArray)   //static can be below where it is evoked
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomArrayString = someArray[randomIndex];
    return randomArrayString;       //all values within {scope} except return one are deleted
}

static int GetCharacterHP(string characterName)         
{ 
    if(characterName.Length < 10)
    {  
        return 10;      //make the game a bit more fair by setting lowest value to 10
    }
    else 
    { 
        return characterName.Length; 
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed.");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} delivers a critical blow!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit for {strike}.");
    }
    return strike;
}