// See https://aka.ms/new-console-template for more information

// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 5;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    if (i == 0)
    {
        animalSpecies = "dog";
        animalID = "d1";
        animalAge = "2";
        animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
        animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
        animalNickname = "lola";
    }
    else if (i == 1)
    {
        animalSpecies = "dog";
        animalID = "d2";
        animalAge = "9";
        animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
        animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
        animalNickname = "loki";
    }
    else if (i == 2)
    {
        animalSpecies = "cat";
        animalID = "c3";
        animalAge = "1";
        animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
        animalPersonalityDescription = "friendly";
        animalNickname = "Puss";
    }
    else if (i == 3)
    {
        animalSpecies = "cat";
        animalID = "c4";
        animalAge = "?";
        animalPhysicalDescription = "";
        animalPersonalityDescription = "";
        animalNickname = "";
    }
    else
    {
        animalSpecies = "";
        animalID = "";
        animalAge = "";
        animalPhysicalDescription = "";
        animalPersonalityDescription = "";
        animalNickname = "";
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}





string exitExecution = "Exit";

// Menu selection input for user
do
{
    // display the top-level menu options
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    // Read user input options and check whether it is null or not
    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower().Trim();

        if (menuSelection != "")
        {
            Console.WriteLine($"You selected menu option {menuSelection}.");
        }

        // Check whether input option is exit 
        if (menuSelection == exitExecution.ToLower())
        {
            Console.WriteLine("You have choosen to exit the application. Thank You.");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
            continue;
        }

        // Response for selected menu by user
        switch (menuSelection)
        {
            case "1":
                // List all animals in multidimensional array that has been created
                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: ")
                    {
                        Console.WriteLine("-----------------");
                        for (int j = 0; j < 6; j++)
                        {
                            Console.WriteLine(ourAnimals[i, j]);
                        }
                    }
                } 

                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;

            case "2":
                /// Adding new pet 
                Console.WriteLine("This is adding animals menu option");

                // Looping the question of adding new pet until the user enter "exit"
                bool isDone = false;
                int iterCount = 0;
                do 
                {
                    // Count the number of pets in array
                    int animalCount = 0;
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            animalCount++;
                        }
                    }

                    Console.WriteLine($"The amount of animals in our array now are: {animalCount}");


                    string? userNewInfo;
                    Console.WriteLine("");
                    if (iterCount > 0)
                    {
                        Console.WriteLine("Do you want to enter another new animal info to our data? (y/n/exit)");
                    }
                    else 
                    {
                        Console.WriteLine("Do you want to enter new animal info to our data? (y/n/exit)");
                    }

                    userNewInfo = Console.ReadLine();

                    if (userNewInfo != null)
                    {
                        userNewInfo = userNewInfo.Trim().ToLower();

                        switch (userNewInfo)
                        {
                            // Adding new pet case
                            case "y":
                                // Adding new pet if max pets haven't been reached
                                if (animalCount < maxPets)
                                {
                                    string newAnimalId;
                                    string? newAnimalSpecies;
                                    string? newAnimalAge;
                                    string? newAnimalPhysicalDescription;
                                    string? newAnimalPersonalityDescription;
                                    string? newAnimalNickname;

                                    Console.WriteLine("Input the characteristics of the animal you want to add");
                                    string[,] newPet = new string[1, 6];
                                    Console.WriteLine("Animal Species?");
                                    newAnimalSpecies = Console.ReadLine();
                                    Console.WriteLine("Animal Age?");
                                    newAnimalAge = Console.ReadLine();
                                    Console.WriteLine("Animal Physical Description?");
                                    newAnimalPhysicalDescription = Console.ReadLine();
                                    Console.WriteLine("Animal Personality Description?");
                                    newAnimalPersonalityDescription = Console.ReadLine();
                                    Console.WriteLine("Animal Nickname?");
                                    newAnimalNickname = Console.ReadLine();

                                    newAnimalId = newAnimalSpecies.Substring(0, 1) + (animalCount + 1).ToString();
                                    newPet[0, 0] = "ID #: " + newAnimalId;
                                    newPet[0, 1] = "Species: " + newAnimalSpecies;
                                    newPet[0, 2] = "Age: " + newAnimalAge;
                                    newPet[0, 3] = "Nickname: " + newAnimalNickname;
                                    newPet[0, 4] = "Physical description: " + newAnimalPhysicalDescription;
                                    newPet[0, 5] = "Personality: " + newAnimalPersonalityDescription;

                                    for (int i = 0; i < 6; i++)
                                    {
                                        ourAnimals[animalCount, i] = newPet[0, i];
                                    }

                                    Console.WriteLine("Your entry has been added");
                                    Console.WriteLine("------New Pet----------");
                                    for (int i = 0; i < 6; i++)
                                    {
                                        Console.WriteLine(ourAnimals[animalCount, i]);
                                    }

                                    iterCount++;
                                }  

                                else if (animalCount >= maxPets)
                                {
                                    Console.WriteLine("The number of max pets have been reached.");
                                    Console.WriteLine("Please delete one entry to add another entry");
                                }

                                break;

                            case "n":
                                Console.WriteLine("Going back to main menu...");
                                isDone = true;
                                break;
                            
                            case "exit":
                                Console.WriteLine("Loading back to main menu...");
                                isDone = true;
                                break;

                            default:
                                Console.WriteLine("Your input is invalid. Please select between y or n. Enter \"Exit\" to exit this menu");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your input is invalid. Please select between y or n. Enter \"Exit\" to exit this menu");
                    }
                } while (isDone == false);

                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;

            case "3":
                Console.WriteLine("this app feature is coming soon - please check back to see progress.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
            case "4":
                Console.WriteLine("this app feature is coming soon - please check back to see progress.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
            case "5":
                Console.WriteLine("this app feature is coming soon - please check back to see progress.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
            case "6":
                Console.WriteLine("this app feature is coming soon - please check back to see progress.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
            case "7":
                Console.WriteLine("this app feature is coming soon - please check back to see progress.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
            case "8":
                Console.WriteLine("this app feature is coming soon - please check back to see progress.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break; 
            case "":
                Console.WriteLine("You haven't inputed anything. Please try again");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;
            default:
                Console.WriteLine("Your input is invalid.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;                               
        }
    }
    else
    {
        Console.WriteLine("Your input is invalid. Please try again.");
        readResult = Console.ReadLine();
    }

} while (menuSelection != exitExecution.ToLower());

