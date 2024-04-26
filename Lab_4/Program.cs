using System;
using System.Numerics;

public class ComplexNumber
{
    private double p; // модуль
    private double phi; // аргумент

    public ComplexNumber(double p, double phi)
    {
        this.p = p;
        this.phi = phi;
    }

    public ComplexNumber Power(int n)
    {
        return new ComplexNumber(Math.Pow(p, n), n * phi);
    }

    public string ToTrigonometricForm()
    {
        return $"{p} (cos({phi}) + i sin({phi}))";
    }

    public Complex ToAlgebraicForm()
    {
        return new Complex(p * Math.Cos(phi), p * Math.Sin(phi));
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        Complex x = a.ToAlgebraicForm() + b.ToAlgebraicForm();
        return new ComplexNumber(x.Magnitude, x.Phase);
    }

    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
    {
        Complex x = a.ToAlgebraicForm() - b.ToAlgebraicForm();
        return new ComplexNumber(x.Magnitude, x.Phase);
    }

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.p * b.p, a.phi + b.phi);
    }

    public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.p / b.p, a.phi - b.phi);
    }

    public static bool operator >(ComplexNumber a, ComplexNumber b)
    {
        return a.p > b.p;
    }

    public static bool operator <(ComplexNumber a, ComplexNumber b)
    {
        return a.p < b.p;
    }
}

class Program
{
    static void Main()
    {
        ComplexNumber a = new ComplexNumber(1, Math.PI / 3);
        ComplexNumber b = new ComplexNumber(2, Math.PI / 4);
        ComplexNumber c = new ComplexNumber(3, Math.PI / 6);
        ComplexNumber d = new ComplexNumber(4, Math.PI / 2);

        ComplexNumber R = b.Power(3) + ((a + b) / (c - a)) * d;

        Console.WriteLine($"R = {R.ToTrigonometricForm()}");
    }
}