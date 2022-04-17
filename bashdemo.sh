#!/bin/bash

#to quit a running process, use 'ctrl + c'
#output
echo Welcome to my bash demo! What is my name

#input
read input

#create and instantiate a variable
myVar=Jack

#this whole line is a comment

echo Your name is $input. #string interpolation- the act of putting the value of the variable into the string
echo Your cat\'s name is $myVar.

#get some numbers
echo Give me the first number
read num1
echo The number is $num1

echo Give me the second number
read num2
echo The number is $num2

#adding
expr $num1 + $num2
echo The Sum is $(( num1 + num2 ))

#subtracting
expr $num1 - $num2
echo The differences is $(( num1 - num2 ))

#multiplication
expr $num1 \* $num2
echo The product is $(( num1 * num2 ))

#division
expr $num1 / $num2
echo The quotient is $(( num1 / num2 ))
#5/4 = 1  because dividing integers leaves the whole number and truncates any remainder

#loops (control flow statements)
#if statement
if [ $num1 -gt $num2 ]
then
    echo $num1 is greater than $num2.
elif [ $num1 -lt $num2 ] #else.... if this is true....
    then
    echo $num1 is less than $num2.
else
    echo $num1 is equal to $num2.
fi #needed to close the loop

#while loop
while [ $num1 -lt 10 ]
do
    (( num1++ ))
    echo The value of num1 is $num1.
    #num1=$(( num1 + 1 ))  same as above statement
done

#until loop (do-while loop)
until [ $num1 -gt 20 ]
do
    (( num1++ ))
    echo The new value of num1 is $num1.
done

#for loop
for x in {0..10}
do
    echo The value of the iterator is $x
done

for (( i=$num1; i>1; i-- ))
do
    echo The value of i is $i.
done

#break keyword
for val in {10..15} #you could do {10..15..2} to increment by 2
do 
    echo the value is ${val}
    if [ $val -eq 12 ]
    then
        echo breaking now!!
        break
    fi
done

#continue keyword jumps out of the current cycle and starts the next cycle immediately
for val in {10..15}
do 
    echo the value is ${val}
    if [ $val -eq 12 ]
    then
        echo Do you want to subtract 5 from val?
        read input
        if [ $input == "yes" ]
        then 
            val=$(( val - 5 ))
        fi

        if [ $val -eq 7 ]
        then
            echo continuing now!!
            continue
        fi
    fi
done

#function - they must be declared above any place where it is called
multiply () {
    echo This is 
    expr $(( num1 * num2 ))
}
