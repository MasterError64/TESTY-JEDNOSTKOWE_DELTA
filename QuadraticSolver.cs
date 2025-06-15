
using System;

namespace QuadraticEquationSolver
{
    public class QuadraticSolver
    {
        /// <summary>
        /// Rozwiązuje równanie kwadratowe ax^2 + bx + c = 0.
        /// Zwraca krotkę: liczba pierwiastków, oraz wartości pierwiastków (jeśli istnieją).
        /// </summary>
        public static (int NumberOfRoots, double? Root1, double? Root2) Solve(double a, double b, double c)
        {
            if (a == 0)
            {
                throw new ArgumentException("Współczynnik 'a' nie może być równy 0 w równaniu kwadratowym.");
            }

            double discriminant = CalculateDiscriminant(a, b, c);

            if (discriminant < 0)
            {
                return (0, null, null); // brak pierwiastków rzeczywistych
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a); // jeden pierwiastek rzeczywisty
                return (1, root, null);
            }
            else
            {
                // dwa pierwiastki rzeczywiste
                (double root1, double root2) = CalculateRoots(a, b, discriminant);
                return (2, root1, root2);
            }
        }

        /// <summary>
        /// Oblicza deltę (wyróżnik) dla równania kwadratowego.
        /// </summary>
        private static double CalculateDiscriminant(double a, double b, double c)
        {
            return (b * b) - (4 * a * c);
        }

        /// <summary>
        /// Oblicza dwa pierwiastki rzeczywiste dla delta > 0.
        /// </summary>
        private static (double, double) CalculateRoots(double a, double b, double discriminant)
        {
            double sqrtDelta = Math.Sqrt(discriminant);
            double root1 = (-b + sqrtDelta) / (2 * a);
            double root2 = (-b - sqrtDelta) / (2 * a);
            return (root1, root2);
        }
    }
}
