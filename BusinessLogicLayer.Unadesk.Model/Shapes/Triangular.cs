using BusinessLogicLayer.Unadesk.Model.Enumeration;
using BusinessLogicLayer.Unadesk.Model.Exceptions;

using DomainErrors = BusinessLogicLayer.Unadesk.Model.Assets.Strings.Errors.Domain;

namespace BusinessLogicLayer.Unadesk.Model.Shapes;

/// <summary>
/// Triangular entity model class.
/// </summary>
public sealed class Triangular : Shape
{
    /// <summary>
    /// Shape type field.
    /// </summary>
    private ShapeType _shapeType;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="firstSide">Triangular first side value.</param>
    /// <param name="secondSide">Triangular second side value.</param>
    /// <param name="thirdSide">Triangular third side value.</param>
    public Triangular(
        double firstSide,
        double secondSide,
        double thirdSide
    ) {
        if (firstSide <= 0.0)
        {
            throw new DomainModelException(
                string.Format(
                    DomainErrors.TRIANGULAR_SIDE_HAS_INCORECT_VALUE,
                    firstSide
                )
            );
        }

        if (secondSide <= 0.0)
        {
            throw new DomainModelException(
                string.Format(
                    DomainErrors.TRIANGULAR_SIDE_HAS_INCORECT_VALUE,
                    secondSide
                )
            );
        }

        if (thirdSide <= 0.0)
        {
            throw new DomainModelException(
                string.Format(
                    DomainErrors.TRIANGULAR_SIDE_HAS_INCORECT_VALUE,
                    thirdSide
                )
            );
        }

        if (firstSide + secondSide <= thirdSide ||
            firstSide + thirdSide <= secondSide ||
            secondSide + thirdSide <= firstSide
        ) {
            throw new DomainModelException(DomainErrors.TRIANGULAR_SIDES_IS_WRONG);
        }

        FirstSide = firstSide;
        SecondSide = secondSide;
        ThirdSide = thirdSide;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="firstSide">Triangular first side value.</param>
    /// <param name="secondSide">Triangular second side value.</param>
    /// <param name="thirdSide">Triangular third side value.</param>
    public Triangular(
        int firstSide,
        int secondSide,
        int thirdSide
    ) : this(
        Convert.ToDouble(firstSide),
        Convert.ToDouble(secondSide),
        Convert.ToDouble(thirdSide)
    ) {
    }

    /// <summary>
    /// Triangular first side property.
    /// </summary>
    public double FirstSide { get; }

    /// <summary>
    /// Triangular second side property.
    /// </summary>
    public double SecondSide { get; }

    /// <summary>
    /// Triangular third side property.
    /// </summary>
    public double ThirdSide { get; }

    /// <summary>
    /// Shape type getting method.
    /// </summary>
    /// <returns>Shape type value.</returns>
    public override ShapeType GetShapeType()
    {
        if (this._shapeType != default)
        {
            return this._shapeType;
        }

        var firstSideSquare = this.FirstSide * this.FirstSide;
        var secondSideSquare = this.SecondSide * this.SecondSide;
        var thirdSideSquare = this.ThirdSide * this.ThirdSide;

        var squareTwoSides = 0.0;
        // ReSharper disable once RedundantAssignment
        var greatestSquareSide = 0.0;

        if (firstSideSquare > secondSideSquare)
        {
            squareTwoSides += secondSideSquare;
            greatestSquareSide = firstSideSquare;
        }
        else
        {
            squareTwoSides += firstSideSquare;
            greatestSquareSide = secondSideSquare;
        }

        if (greatestSquareSide > thirdSideSquare)
        {
            squareTwoSides += thirdSideSquare;
        }
        else
        {
            squareTwoSides += greatestSquareSide;
            greatestSquareSide = thirdSideSquare;
        }

        if (greatestSquareSide < squareTwoSides)
        {
            this._shapeType = ShapeType.RightTriangle;

            return ShapeType.AcuteTriangle;
        }
        
        if (greatestSquareSide > squareTwoSides)
        {
            this._shapeType = ShapeType.ObtuseTriangle;

            return ShapeType.ObtuseTriangle;
        }
        
        this._shapeType = ShapeType.AcuteTriangle;

        return ShapeType.RightTriangle;
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        var triangularType = this._shapeType != default ?
            this._shapeType :
            this.GetShapeType();

        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "First side: {0}, second side: {1}, third side {2}, type: {3}",
            this.FirstSide,
            this.SecondSide,
            this.ThirdSide,
            triangularType
        );
    }
}