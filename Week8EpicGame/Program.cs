string folderPath = @"C:\Users\Documents\Data\";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapons = { "a potato", "a pringles can", "a spork", "a bible" };

//string[] heroes = { "Joonas", "Vanaema", "Vanaisa" };
//string[] villains = { "Juhan Seen", "Ville", "Kalmer" };

string hero = GetRandomValue(heroes);
string heroweapon = GetRandomValue(weapons);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP) wants to save the day with {heroweapon}!");

string villain = GetRandomValue(villains);
string villainweapon = GetRandomValue(weapons);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;
Console.WriteLine($"Today {villain} ({villainHP} HP) tries to take over the world with {villainweapon}!");

while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

Console.WriteLine($"{hero} HP: {heroHP}");
Console.WriteLine($"{villain} HP: {villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"I can't believe you've done this!");
}
else
{
    Console.WriteLine("Both lose");
}
static string GetRandomValue(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
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
    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;
}