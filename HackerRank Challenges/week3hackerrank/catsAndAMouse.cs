using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the catAndMouse function below.
    static string catAndMouse(int x, int y, int z) {

        //Absolute values of cat A to mouse and cat B to mouse
        int catAToMouse = Math.Abs(x-z);
        int catBToMouse = Math.Abs(y-z);
        
        //Conditional statement determining which animal "wins"
        string result;
        if (catAToMouse == catBToMouse){
            result = "Mouse C";
        }
        else if (catAToMouse < catBToMouse){
            result = "Cat A";
        } 
        else {
            result = "Cat B";
        }
        
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string[] xyz = Console.ReadLine().Split(' ');

            int x = Convert.ToInt32(xyz[0]);

            int y = Convert.ToInt32(xyz[1]);

            int z = Convert.ToInt32(xyz[2]);

            string result = catAndMouse(x, y, z);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
