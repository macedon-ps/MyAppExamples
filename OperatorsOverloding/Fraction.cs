public class Fraction
{
    public int Nom { get; set; }
    public int Den { get; set; }

    public Fraction(int nominator, int denominator)
    {
        if(denominator == 0)
        {
            throw new Exception("Знаменатель дроби не может быть равен 0!");
        }
        Nom = nominator;
        Den = denominator;
    }

    public static Fraction operator +(Fraction fract1, Fraction fract2)
    {
        var nom = fract1.Nom * fract2.Den + fract1.Den * fract2.Nom;
        var den = fract1.Den * fract2.Den;
        return new Fraction(nom,den);
    }

    public static Fraction operator -(Fraction fract1, Fraction fract2)
    {
        var nom = fract1.Nom * fract2.Den - fract1.Den * fract2.Nom;
        var den = fract1.Den * fract2.Den;
        return new Fraction(nom, den);
    }

    public static Fraction operator *(Fraction fract1, Fraction fract2)
    {
        var nom = fract1.Nom * fract2.Nom;
        var den = fract1.Den * fract2.Den;
        return new Fraction(nom, den);
    }
    public static Fraction operator /(Fraction fract1, Fraction fract2)
    {
        if (fract2.Nom != 0)
        {
            var nom = fract1.Nom * fract2.Den;
            var den = fract1.Den * fract2.Nom;
            return new Fraction(nom, den);
        }
        else
        {
            throw new Exception("На 0 делить нельзя!");
        }

    }

    public override string ToString()
    {
        return $"{Nom}/{Den}";
    }
}