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

//////////////////////////////////////////////////////
string exitExecution = "Exit";

// Menu selection input for user
do
{
    // Display the top-level menu options
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

    // Read user input options
    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower().Trim();

        // Check whether input option is not ""
        if (menuSelection != "")
        {
            Console.WriteLine($"You selected menu {menuSelection}.");
        }

        // Check whether input option is exit 
        if (menuSelection == exitExecution.ToLower())
        {
            Console.WriteLine("Thank You for using our application.");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
            continue;
        }

        // Count the number of pets in our Animals database
        int petCount = 0;
        for (int i = 0; i < maxPets; i++)
        {
            if (ourAnimals[i, 0] != "ID #: ")
            {
                petCount += 1;
            }
        }

        // Multiple response based on the user input
        switch (menuSelection)
        {
            /*************************************************************************************************
                Option 1 is to list all animals or pets information that is stored in the database array.
            **************************************************************************************************/
            case "1":
                // List all animals in database that has been created
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

            /*************************************************************************************************
                Option 2 is to stored new animals or pets information in the database array if the maximum
                managable pets has not been reached.
            **************************************************************************************************/
            case "2":
                Console.WriteLine("This is new pet information menu.");
                string anotherPet = "y";

                while (anotherPet == "y" && petCount < maxPets)
                {
                    Console.WriteLine("Enter your new pet information here:\n");
                    bool validEntry = false;

                    // Animal Species Entry. Can only be a dog or a cat.
                    do
                    {
                        Console.WriteLine("\n\rEnter 'dog' or 'cat' to create new entry");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalSpecies = readResult.ToLower();
                            if (animalSpecies != "dog" && animalSpecies != "cat")
                            {
                                validEntry = false;
                            }
                            else
                            {
                                validEntry = true;
                            }
                        }
                    } while (validEntry == false);

                    // Build the animal the ID number - for example C1, C2, D3 (for Cat 1, Cat 2, Dog 3)
                    animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                    // Animal Age Entry. Can only be an integer or "?".
                    do
                    {
                        int petAge;
                        Console.WriteLine("Enter pet age or '?' if unknown:");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalAge = readResult;
                            if (readResult != "?")
                            {
                                validEntry = int.TryParse(animalAge, out petAge);
                            }
                            else
                            {
                                validEntry = true;
                            }
                        }
                    } while (validEntry == false);

                    // Animal Physical Description Entry. The entry can be blank.
                    do
                    {
                        Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPhysicalDescription = readResult.ToLower().Trim();
                            if (animalPhysicalDescription == "")
                            {
                                animalPhysicalDescription = "tbd";
                            }
                        }
                    } while (animalPhysicalDescription == "");

                    // Animal Personality Entry. The entry can be blank.
                    do
                    {
                        Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPersonalityDescription = readResult.ToLower().Trim();
                            if (animalPersonalityDescription == "")
                            {
                                animalPersonalityDescription = "tbd";
                            }
                        }
                    } while (animalPersonalityDescription == "");

                    // Animal Nickname entry. The entry can be blank.
                    do
                    {
                        Console.WriteLine("Enter a nickname for the pet");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalNickname = readResult.ToLower().Trim();
                            if(animalNickname == "")
                            {
                                animalNickname = "tbd";
                            }
                        }
                    } while (animalNickname == "");

                    // Store the pet information in the ourAnimals array (zero based)
                    ourAnimals[petCount, 0] = "ID #: " + animalID;
                    ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                    ourAnimals[petCount, 2] = "Age: " + animalAge;
                    ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                    ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                    ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;
                    Console.WriteLine("The pet information has been added to our database");

                    // Increment of pet count for adding new animal (y)
                    petCount += 1;
                    
                    if (petCount < maxPets)
                    {
                        Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
                        Console.WriteLine("Do you want to enter info about another pet? (y/n)");
                        do
                        {
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                anotherPet = readResult.ToLower().Trim();
                            }
                        } while (anotherPet != "y" && anotherPet != "n");
                    }
                }

                if (petCount >= maxPets)
                {
                    Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                }

                break;

            /*************************************************************************************************
                Option 3 is to update existing animals or pets information in the database array if the pet Age or
                Physical Description is still empty. 
            **************************************************************************************************/
            case "3":
                // Displaying information
                Console.WriteLine("\nThis menu ensures all your pets have age and physical description.");
                Console.WriteLine("There will be a pet ID and you can enter age and physical description correspond to its pet ID.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();

                for (int i = 0; i < petCount; i++)
                {
                    if (ourAnimals[i, 2] == "Age: ?")
                    {
                        bool validEntry = false;
                        int petAge;
                        do
                        {
                            Console.WriteLine($"Enter an age for {ourAnimals[i,0]}");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalAge = readResult.Trim();
                                validEntry = int.TryParse(animalAge, out petAge);
                            }
                        } while (validEntry == false);

                        // Update pet age missing information for corresponding ID 
                        ourAnimals[i, 2] = $"Age: {animalAge}";
                    }
                    if (ourAnimals[i, 4] == "Physical description: tbd" || ourAnimals[i, 4] == "Physical description: ")
                    {
                        bool validEntry = false;
                        do
                        {
                            Console.WriteLine($"Enter physical descrition (size, color, breed, gender, weight, housebroken) for {ourAnimals[i,0]}");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPhysicalDescription = readResult.Trim();
                                if (animalPhysicalDescription != "")
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        // Update pet physical description missing information for corresponding ID 
                        ourAnimals[i, 4] = $"Physical description: {animalPhysicalDescription}";
                    }
                } 

                Console.WriteLine("All pets age and physical description is now filled up");
                Console.WriteLine("Press Enter to Continue");
                readResult = Console.ReadLine();
                break;
            
            /*************************************************************************************************
                Option 4 is to update existing animals or pets information in the database array if the pet 
                Personality or Nickname is still empty. 
            **************************************************************************************************/
            case "4":
                // Displaying information
                Console.WriteLine("\nThis menu ensures all your pets have nickname and personality description information.");
                Console.WriteLine("There will be a pet ID and you can enter personality description and nickname correspond to its pet ID.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();

                for (int i = 0; i < petCount; i++)
                {
                    if (ourAnimals[i, 3] == "Nickname: ")
                    {
                        bool validEntry = false;
                        do
                        {
                            Console.WriteLine($"Enter a nickname for {ourAnimals[i,0]}");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalNickname = readResult.Trim();
                                if (animalNickname != "")
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        // Update pet age missing information for corresponding ID 
                        ourAnimals[i, 3] = $"Nickname: {animalNickname}";
                    }
                    if (ourAnimals[i, 5] == "Personality: tbd" || ourAnimals[i, 5] == "Personality: ")
                    {
                        bool validEntry = false;
                        do
                        {
                            Console.WriteLine($"Enter a description of the pet's personality (likes or dislikes, tricks, energy level) for {ourAnimals[i,0]}");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPersonalityDescription = readResult.Trim();
                                if (animalPersonalityDescription != "")
                                {
                                    validEntry = true;
                                }
                            }
                        } while (validEntry == false);

                        // Update pet physical description missing information for corresponding ID 
                        ourAnimals[i, 5] = $"Personality: {animalPersonalityDescription}";
                    }
                } 

                Console.WriteLine("All pets nickname and personality description is now filled up");
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
                Console.WriteLine("Your input is invalid. Please enter appropiate option between 1-8 or 'exit' to exit our application");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
                break;                               
        }
    }

    // if menu selection read result is null
    else
    {
        Console.WriteLine("Your input is invalid. Please enter appropiate option between 1-8 or 'exit' to exit our application");
        readResult = Console.ReadLine();
    }

} while (menuSelection != exitExecution.ToLower());

