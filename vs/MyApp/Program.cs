using System;
using  System.Collections.Generic;
using  System.Linq;

class Polynomial
{
	private List<double> _coefs;
	public IReadOnlyList<double> Coefs => _coefs;
	public Polynomial (IEnumerable<double> coefs)
	{
		_coefs = coefs.ToList();
	
	}
	
	public double Evaluate(double x)
	{
		double result =0;
		for(int i = _coefs.Count -1; i>=0; i--)
			result =result * x+ _coefs [i];
		return result;
	}
	
	public double this[int i]
	{
		get => _coefs[i];
		set => _coefs[i] = value;
	}
	
	public override string ToString(){
		var  terms = new  List<string>();
		for (int i=0; i< _coefs.Count; i++)
		{
			double c= _coefs[i];
			if (i==0) terms.Add($"{c}x^{i}");
			else if (i==1) terms.Add($"{c}x");
			else terms.Add($"{c}x^{i}");
		}
		return "P(x) =" +string.Join("+", terms);
	}

    public void PrintCoefs()
    {
        for(int i = _coefs.Count -1; i< _coefs.Count; i+=1)
            Console.WriteLine($"{_coefs[i]}" );
    }
    public Polynomial Add(Polynomial other)
    {
        var t =new  Polynomial(new  double[]{1,2,3});


    }
	class Program
	{
		static void Main()
		{
			var p =new  Polynomial(new  double[]{1,2,3});
			Console.WriteLine(p);
			Console.WriteLine("P(2) = " + p.Evaluate(2));
		}
    }
}
						   
	