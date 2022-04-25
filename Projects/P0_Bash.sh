#!/bin/bash

#This script replicates a calculator that can add, subtract, multiply or divide

echo -e "\nWelcome to Tyler's simple calculator."
echo -e "\nWould you like to:\n+ Add [PRESS 1]\n- Subtract [PRESS 2]\n* Multiply [PRESS 3]\n/ Divide [PRESS 4]"

add () {
    ans=$(( num1 + num2 ))
}

subtract () {
    ans=$(( num1 - num2 ))
}

multiply () {
    ans=$(( num1 * num2 ))
}

divide () {
    #Check for division by 0
    if [ $num2 == "0" ]
    then
        echo -e "You cannot divide by zero. \n\nWould you like to:\n+ Add [PRESS 1]\n- Subtract [PRESS 2]\n* Multiply [PRESS 3]\n/ Divide [PRESS 4]"
        screen
    else
        ans=$(( num1 / num2 ))
    fi
}

#Result function that prints the output
result () {
    echo The answer is $ans.
    echo -e "\nWould you like to:\n+ Add [PRESS 1]\n- Subtract [PRESS 2]\n* Multiply [PRESS 3]\n/ Divide [PRESS 4]\n(or exit the program [PRESS x])" 
}

screen () {
read input

#if statement determining action based on input
if [ $input == "1" ] || [ $input == "2" ] || [ $input == "3" ] || [ $input == "4" ]
then
    echo What is the 1st number \in the equation?
    read num1
    echo What is the 2nd number \in the equation?
    read num2

    if [ $input == "1" ]
    then
        add
        result
        screen
    elif [ $input == "2" ]
    then
        subtract
        result
        screen
    elif [ $input == "3" ]
    then
        multiply
        result
        screen
    elif [ $input == "4" ]
    then
        divide
        result
        screen
    fi

#Enter x or X to exit the program
elif [ $input == "x" ] || [ $input == "X" ]
then
    echo Goodbye, thank you \for your \time.
    exit

#Check to verify input matches possible options
else
    echo You must enter a valid option...
    screen
fi
}

screen