// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var space = new List<int>(){1,5,1,2,3,1,2};
var x=7;
var maxSpace=0;
for(int i=0;i<x-1;i++)
{
    var min = Math.Min(space[i], space[i+1]);
    if (min>maxSpace)
    maxSpace=min;
}
Console.WriteLine(maxSpace);