using System;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

public class randomnumber
{
    public int num;
    public  randomnumber()
    {
        //get random number in num variable
        Random ram = new();      // Random class for access random number
        int number = ram.Next(1,7);
        num = number;
    }
}
public class mainvalue: randomnumber     //inherite from randomnumber method for access random number
{
    //store player dise position number 
    public static int firstdise;
    public static int seconddise;

    public void allvalue(string firstpname, string secondpname)
    {
        //call first player / start the game 
        firstperson f1 = new firstperson();
        f1.first(firstpname, secondpname);
    }
}
public class firstperson:mainvalue      //inhetite from mainvalue for access dise value
{
    public void first(string firstpname,string secondpname)
    {
        int disevalue = firstdise;
        Console.WriteLine("\n\n{0} let's your turn ",firstpname);
        Console.WriteLine("Enter 'f' if you are flip the dise other wise enter 'end' for end the game");
        string yes = Console.ReadLine();
        //check condition if press 'f' then continue game other wise press 'end' so end the game 
        if (yes== "f"){
            new randomnumber();
            Console.WriteLine("dise number is {0} ", num);
            Console.WriteLine("Last dise position "+ disevalue);
            disevalue += num;
            Console.WriteLine("Current dise position "+ disevalue);
            //check snake or not if dise in snake position so decerise dise position 
            if (disevalue == 6 || disevalue == 12 || disevalue == 34 || disevalue == 42)
            {
                Console.WriteLine("OO it is a snake ");
                Console.WriteLine("Your position decerise by 5");
                disevalue = disevalue - 5;
                //check if disevalue is less than zero set zero (0) value for firstdise
                if (disevalue < 0)
                {
                    Console.WriteLine("your dise current position 0");
                    firstdise = 0;
                }
                Console.WriteLine("Your dise current position "+ disevalue);
                firstdise = disevalue;
            }
            //check slider if dise in slider position increase dise position 
            if (disevalue == 2 || disevalue == 26 || disevalue == 30 || disevalue == 41)
            {
                Console.WriteLine("Wow it is a slider  ");
                Console.WriteLine("Your position incerise by 5");
                disevalue = disevalue + 5;
                Console.WriteLine("Your dise current position " + disevalue);
                firstdise = disevalue;
            }
            firstdise = disevalue;
            //check dise position. if dise position is 50 or greater than 50. end the game
            if(firstdise>=50)
                Console.WriteLine("\n\n{0} you Win . . .",firstpname);
            //if dise position is not equal to 50 or not greater than 50. call the secondperson method
            else
            {
                secondperson s1 = new secondperson();
                s1.second(firstpname,secondpname);
            }

        }
        //if enter 'end' then end the game
        else if (yes == "end")
        {
            Console.WriteLine("\n\nGame is over ");
            Console.WriteLine("Thank you . . .");
        }
        //check input if wrong input show msg and call it self
        else
        {
            Console.WriteLine("\nWrong input. try again . . .");
            this.first(firstpname,secondpname);
        }
       
    }
}
public class secondperson:mainvalue     //inherite from mainvalue method for access dise value
{
    public void second(string firstpname,string secondpname)
    {
        int disevalue = seconddise;
        Console.WriteLine("\n\n{0} let's your turn ", secondpname);
        Console.WriteLine("Enter 'f' if you are flip the dise other wise enter 'end' for end the game");
        string yes = Console.ReadLine();
        //check condition if press 'f' then continue game other wise press 'end' so end the game 
        if (yes == "f")
        {
            new randomnumber();
            Console.WriteLine("dise number is {0} ", num);
            Console.WriteLine("Last dise position " + disevalue);
            disevalue += num;
            Console.WriteLine("Current dise position " + disevalue);
            //check snake or not if dise in snake position so decerise dise position 
            if (disevalue == 6 || disevalue == 12 || disevalue == 34 || disevalue == 42)
            {
                Console.WriteLine("OO it is a snake ");
                Console.WriteLine("Your position decerise by 5");
                disevalue = disevalue - 5;
                //check if disevalue is less than zero set zero (0) value for seconddise
                if (disevalue < 0)
                {
                    Console.WriteLine("your dise current position 0");
                    seconddise = 0;
                }
                Console.WriteLine("Your dise current position " + disevalue);
                seconddise = disevalue;
            }
            //check slider if dise in slider position increase dise position 
            if (disevalue == 2 || disevalue == 26 || disevalue == 30 || disevalue == 41)
            {
                Console.WriteLine("Wow it is a slider ");
                Console.WriteLine("Your position incerise by 5");
                disevalue = disevalue + 5;
                Console.WriteLine("Your dise current position " + disevalue);
                seconddise = disevalue;
            }
            seconddise = disevalue;
            //check dise position if dise position is 50 or greater than 50. end the game
            if (seconddise>=50)
                Console.WriteLine("\n\n{0} you Win . . . ",secondpname);
            //if dise position is not equal to 50 or not greater than 50. call the firstperson method
            else
            {
                firstperson f1=new firstperson();
                f1.first(firstpname,secondpname);

            }
        }
        //if enter 'end' then end the game
        else if (yes == "end")
        {
            Console.WriteLine("\n\nGame is over ");
            Console.WriteLine("Thank you . . .");
        }
        //check input if wrong input show msg and call it self
        else
        {
            Console.WriteLine("\nWrong input. try again . . .");
            this.second(firstpname,secondpname);
        }
    }
}
class Program
{
    //entry point of code
    public static void Main(string[] args)
    {
        Console.WriteLine("********** Welcome in snake and slider game **********");   
        //get player name and store in 'firstname' and 'secondname' variable
        Console.Write("Enter first player name :");
        string firstpname=Console.ReadLine();       
        Console.Write("Enter second player name :");
        string secondpname=Console.ReadLine();
        //show information of game
        Console.WriteLine("\nGame end in 50 position ");
        Console.WriteLine("Snake position list is here :-  6,12,34,42");
        Console.WriteLine("Slider position lise is here :- 2,26,30,41");
        //call method
        mainvalue m1=new mainvalue();
        m1.allvalue(firstpname,secondpname);
    }
}
