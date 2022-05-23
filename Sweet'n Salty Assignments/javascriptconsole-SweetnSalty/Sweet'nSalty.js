
//Counter variables to keep track of occurences
let swtTotal = 0;
let sltTotal = 0;
let swsTotal = 0;

//Loops through the numbers (1-1000) and counts the required occurences and prints them to the screen in place of a number
for (let x = 1; x <= 1000; x++)
{
    //If the number is divisible by 5 AND 3, then it's Sweet'n Salty!
    if (x % 5 == 0 && x % 3 == 0)
    {
        console.log("Sweet'n Salty ");
        swsTotal++;
    }
    //Else if the number is divisible by 3, then it's Sweet.
    else if (x % 3 == 0)
    {
        console.log("Sweet ");
        swtTotal++;
    }
    //Else if the number is divisible by 5, then it's Salty
    else if (x % 5 == 0)
    {
        console.log("Salty ");
        sltTotal++;
    }
    //Else just print the sad number
    else
    {
        console.log(x);
    }

    //Returns after 20 numbers/strings on a line
    if (x % 20 == 0)
    {
        console.log("\n");
    
    }
}

//Print the totals
console.log(`\nYou are Sweet ${swtTotal} times.`);
console.log(`You are Salty ${sltTotal} times.`);
console.log(`You are Sweet'n Salty ${swsTotal} times.`);