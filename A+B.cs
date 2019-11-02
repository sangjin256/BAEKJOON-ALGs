// #1000
using System;
using System.IO;

public class Lecture 
{
	public static void Main(string[] args) {
		int[] a = new int[2];
		a = Array.ConvertAll(Console.ReadLine().Split(' '), s => int.Parse(s));
		
		Console.WriteLine(a[0] + a[1]);
	}
}