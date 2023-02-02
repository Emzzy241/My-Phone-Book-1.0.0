using System;
using System.Collections.Generic; //THis tells our program to load the part of the C# language that allows us to use a dictionary object
// specifically, "using System.Collections.Generic" is a namespace built within .NET.... Don't stress yourself too much about namespaces, we wll talk about that soon
// Just take it that: we must add "using System.Collections.Generic" to any program file that uses a Dictionary


class PhoneBook{

// our phoneNumbers dictionary is scoped outside any methods and this is only because we want it to be accessible all through the class{phoneBook) scope
// this is to ensure it has the correct scope, thanks to whagt we did here, methods declared in our class will be able to refer to it
// if it were inside another class, methods from this clas wouldn't be able to access it
// a STATIC variable, this is sometimes referred to as a class variablebecause it is scoped to the level of the class
// although, STATIC VARIABLES can be very useful, we should only use them if the variables need to be accessed everywhee in the class, otherwise we should try to scope our variables more locallyinside of methods

    public static Dictionary<string, string> phoneNumbers = new Dictionary<string, string>(){};
    // in the above we created a dictionary that can only save a string as a key to another string as the value
    

    static void Main(){
        Console.WriteLine("Main Menu");
        Console.WriteLine("Would you like to add a person to your phone book? ['Y' for yes, 'Enter' for no]");

        // picking up the answe our user enters now
        string answer = Console.ReadLine();
        if(answer == "Y" || answer == "y"){
            // we made room for upper or lower case letters
            // calling our AddContact() method if this branch is true
            AddContact();
        }
        else{
            Console.WriteLine("Would you like to Look up a number in your phone book? ['Y' for yes, 'Enter' for no]");
            string lookUpAnswer = Console.ReadLine();
            if(lookUpAnswer == "Y" || lookUpAnswer == "y"){
                // calling our LookUpContact() method if this branch is true
                LookUpContact();
            }
            else{
                Console.WriteLine("Are you finished with this program? ['Y' for yes, 'Enter' for no]");

                string finishedAnswer = Console.ReadLine();
                if(finishedAnswer == "Y" || finishedAnswer == "y"){
                    Console.WriteLine("Goodbye Me dear User");
                } 
                else{
                    // else, call the Main Branch again to restart the application
                    Console.WriteLine("To end the execution of the Application completely, press Ctrl + C");

                    Main();
                }
            }
        }
    }

    static void AddContact(){
        // we create methods in C# with the "static void nameOfMethod format"
        Console.WriteLine("NEW CONTACT");

        
        // for collecting user's name
        Console.WriteLine("Enter a new contact name");
        //  reading the line and storing users name in a variable
        string name = Console.ReadLine();

        // for collecting user's phone number
        Console.WriteLine("Enter the new Contact's Phone Number");
        // reading the line and storing user's phoneNumber in a variable
        string number = Console.ReadLine();

        // a branch to ensure we are not adding an already existing name or PhoneNumber

        if(phoneNumbers.ContainsKey(name)){
            // the ContainsKey is a built-in method that looks through the dictionary it's called upon to see if the dictionary contains the key provided as an argument
            // it returns a boolean that denotes whether the key already exists in the dictionary or not
            // if this boolean is true, our program will tell the user that the person already exists in our phoneBook(address book)
            

            Console.WriteLine("That person is already in your phonebook. THeir number is " + phoneNumbers[name]);
        }
        else{
            // if the contact doesn't exist already in our Dictionary, we call our Add() method on our dictionary(phoneNumbers) to add the name and number of our contact
            // if the boolean returns false, we add the contact to the dictionary with the code:
            phoneNumbers.Add(name, number);
        }

        // when the method has finished adding or displaying the contact, Main() is called again to send us back to the beginning, essentially looping the program until the user quits with(Ctrl + C)
        // later on while updating this application, you can add a section that teels user about Ctrl + C being the onstant Quit..... Don't forget Ctrl + C kicks us out of the C# REPL and also ends the execution of our Applicaton

        Main();
    }

    static void LookUpContact(){
        // writing a line telling user its the LookUpContact section of the Application they're in
        Console.WriteLine("LOOKUP CONTACT");

        //  asking user for the number they want to look up nd storing it in a string variable with Console.ReadLine() method
        Console.WriteLine("Whose number would you like to look up?");
        string friend = Console.ReadLine();

        if(phoneNumbers.ContainsKey(friend)){
            // picking up the user's name to showcase user that they've truly stored the contact details in the past
            // after querying our dictionary with COntainsKey() method, depending on the value of the boolean we either print
            // the contact information or alert the user that the contact name they are looking for does not exist
            
            string alreadyStoredContact = phoneNumbers[friend];
            Console.WriteLine(friend + "\'s phone number is " + alreadyStoredContact);
        }
        else{
            Console.WriteLine("That Person is not in your Phone Book.");
        }
        // after the Method has been completed, we call on Main() to start the program over

        Main();
    }
}