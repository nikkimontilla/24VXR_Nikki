using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBasics : MonoBehaviour
{
    /*Understanding VARIABLES
        Variables are statements
        Organized by type of data
        Ends with a semicolon ; 
        int = integer which is a whole number, default value is = 0
        float = an integer thats a decimal, default value is = 0.0f
        double and decimal and floats are all similar but 
        strings = characters and words defined by quotation "", default value is = null
        bool = true or false, default value is = false */

    //Access modifiers private and public

    //This variable is directly under the class CodeBasics so it can be accessed in both start() and update()
    private int example = 0;

    //Understanding OPERATORS
    // change the value of variable
    /*Arithmetic Operators
    addition +
    subtraction -
    multiplication *
    division /
    modulus % returns the remainder of division value*/

    //Assignment operators
    
    private int level = 1;

    //Addition assignment +=
    private int coins = 10;

    //substraction assignment -=

    //comparison operations
    /* equal to ==
       not equal to !=
       greater than >
       less than <
       greater than or equal to >=
       less than or equal to <= */

    //logical operators: compare two variables
    /* and &&
       or ||
       not ! */

    //increment / decrement operators
    /* increment ++
       decrement -- */

    //bitmap operators

    // dot operator . 
    /* gets you access to components
     put . after classname */

    public Renderer theRenderer;


    //EXAMPLES OF VARIABLES 

    //INT EXAMPLE
    private int groceriesSubtotal = 100;

    //FLOAT EXAMPLE
    private float grade = 85f;

    //STRING EXAMPLE
    private string myName = "Nikki";

    //BOOL EXAMPLE
    private bool lateSubmission = false;

// Start is called before the first frame update
    void Start()
    {
        theRenderer = GetComponent<Renderer>();

        //value to this variable is assigned as 0
        int health = 3;
        level++;

        //ARITHMETIC OPERATOR EXAMPLES

        //ADDITION OPERATOR EXAMPLE
        int groceriesTotal = groceriesSubtotal + 5;

        //SUBSTRACTION OPERATOR EXAMPLE
        int snackPrices = groceriesSubtotal - 80;

        //MULTIPLICATION EXAMPLE
        int yearlyGroceries = groceriesTotal * 12;

        //DIVISION OPERATOR EXAMPLE
        int startingHealth = health / 3;

        //MODULUS EXAMPLE
        int dailyGroceries = groceriesTotal % 365;

    }

    //Update is called once per frame
    void Update()
    {
        coins += 5; //adds 5 more coins to my already 10 coins, so 15 coins 

        if (myName == "Nikki")
        {
        
        }

        //ASSIGNMENT OPERATORS EXAMPLES 
        //EQUAL EXAMPLE
        int num1 = 5;
        int num2 = 8;
        int num3 = 10;

        //ADDITION ASSIGNMENT EXAMPLE
        groceriesSubtotal += 20;

        //SUBSTRACTION ASSIGNMENT EXAMPLE 
        grade -= 5;


        //COMPARISON OPERATORS EXAMPLES + LOGICAL OPERATORS EXAMPLES
        //EQUAL TO EXAMPLE
        if (num1 == num2)
        {
            print("Greeting1 is the same as Greeting2");
        }
        else
        {
            print("num1 is not the same as num2");
        }

        //NOT EQUAL TO EXAMPLE
        string albertaCity1 = "Calgary";
        string albertaCity2 = "Lethbridge";
        if (albertaCity1 != albertaCity2)
        {
            print("Different cities");
        }
        else
        {
            print("Same city");
        }

        //GREATER THAN EXAMPLE
        if (example > num3)
        {
            print("0 is larger than num3");
        }
        else
        {
            print("0 is smaller than num3");
        }

        //LESS THAN EXAMPLE 
        if (num1 < num2)
        {
            print("yes");
        }

        //GREATER THAN AND EQUAL TO + LESS THAN AND EQUAL TO EXAMPLE + AND EXAMPLE
        if (num1 >= num3 && num2 <= num1)
        {
            print("correct");
        }

        //OR EXAMPLE
        string goodMood1 = "Happy";
        string goodmood2 = "Excited";
        if (goodMood1 == "Happy" || goodmood2 == "Excited")
        {
            print("I am in a good mood");
        }

        //NOT EXAMPLE
        if (!lateSubmission)
        {
            Debug.Log("Submission was on time");
        }

        //INCREMENTS AND DECREMENT OPERATORS EXAMPLE
        //INCREMENT EXAMPLE
        int chapterNum = 1;
        chapterNum++;

        //DECREMENT EXAMPLE
        int cookies = 500;
        cookies--;

        //EXAMPLE OF DOT OPERATOR
        theRenderer.enabled = false;
    }
}
