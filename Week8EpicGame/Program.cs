//string[] heroes = {"Bob", "Batman", "Tommy Bunz", "Bambureh"};
//string[] villains = {"Bart Krishna", "Kevin", "Carlito", "Cthulhu", "Klop"};
//^ manual array creation
//reading data from file v

string folderPath = @"D:\OneDrive - Tallinna Tehnikakõrgkool\Programmeerimine\data\";        //remove double slashes, add @, *add slash to end unless using Path.Combine()
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));        //reads data as array entries; File.ReadAllLines(folderPath+heroFile) also works
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));   //but Path.Combine is smarter, takes OS into account

string[] weapon = { "wand", "fork", "apple", "Lego sword", "stone" };

string hero = GetRandomArrayValue(heroes);
string villain = GetRandomArrayValue(villains);
string heroWeapon = GetRandomArrayValue(weapon);
string villainWeapon = GetRandomArrayValue(weapon);

Console.WriteLine($"{hero} is your only hope...{villain} is on the rise. A battle of {heroWeapon} versus {villainWeapon}!");

static string GetRandomArrayValue(string[] someArray)   //static can be below where it is evoked
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomArrayString = someArray[randomIndex];
    return randomArrayString;       //all values within {scope} except return one are deleted
}