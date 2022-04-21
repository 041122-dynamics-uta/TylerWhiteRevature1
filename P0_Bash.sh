#!/bin/bash

#This script replicates a calculator that can add, subtract, multiply or divide

echo -e "\nWelcome to my simple calculator."

screen () {
echo -e "\nWould you like to:\n+ Add [PRESS 1]\n- Subtract [PRESS 2]\n* Multiply [PRESS 3]\n/ Divide [PRESS 4]\n(or exit the program [PRESS x])"
read input    
if [ $input == "1" ] || [ $input == "2" ] || [ $input == "3" ] || [ $input == "4" ]
then
    echo What is the 1st number \in the equation?
    read num1
    echo What is the 2nd number \in the equation?
    read num2
    
    add () {
        output1=$(( num1 + num2 ))
    }

    subtract () {
        echo The answer is $(( num1 - num2 )).
    }

    multiply () {
        echo The answer is $(( num1 * num2 )).
    }

    divide () {
        echo The answer is $(( num1 / num2 )).
    }



    if [ $input == "1" ]
    then
        result () {
            echo The answer is $output1.
        }
        result
        screen
    elif [ $input == "2" ]
    then
        subtract
        screen
    elif [ $input == "3" ]
    then
        multiply
        screen
    elif [ $input == "4" ]
    then
        divide
        screen
    fi

elif [ $input == "x" ] || [ $input == "X" ]
then
    echo Goodbye, thank you \for your \time.
    exit

else
    echo You must enter a valid option...
    screen
fi
}

screen




