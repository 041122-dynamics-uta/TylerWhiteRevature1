#!/bin/bash

read char1

if [ $char1 == "Y" ] || [ $char1 == "y" ]
then
    echo YES
elif [ $char1 == "N" ] || [ $char1 == "n" ]
then
    echo NO

fi