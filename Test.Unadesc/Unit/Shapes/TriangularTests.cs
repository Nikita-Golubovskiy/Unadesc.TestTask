using BusinessLogicLayer.Unadesk.Model.Enumeration;
using BusinessLogicLayer.Unadesk.Model.Exceptions;
using BusinessLogicLayer.Unadesk.Model.Shapes;
using Xunit;

namespace Test.Unadesk.Unit.Shapes;

/// <summary>
/// <see cref="Triangular">Triangular</see> model tests.
/// </summary>
public class TriangularTests
{
    /// <summary>
    /// Triangular instance constructed with correct parameters testing method.
    /// </summary>
    /// <param name="firstSide">Triangular first side value.</param>
    /// <param name="secondSide">Triangular second side value.</param>
    /// <param name="thirdSide">Triangular third side value.</param>
    [Theory]
    [InlineData(10.0, 10.0, 10.0)]
    [InlineData(4.0, 5.0, 5.0)]
    [InlineData(10.0, 5.0, 6.0)]
    public void Triangular_WhenConstructWithCorrectParameters_ReturnsProperInstance(
        double firstSide,
        double secondSide,
        double thirdSide
    ) {
        var triangular = new Triangular(
            firstSide,
            secondSide,
            thirdSide
        );

        Assert.Equal(triangular.FirstSide, firstSide);
        Assert.Equal(triangular.SecondSide, secondSide);
        Assert.Equal(triangular.ThirdSide, thirdSide);
    }

    /// <summary>
    /// Triangular instance constructed with not correct parameters testing method.
    /// </summary>
    /// <param name="firstSide">Triangular first side value.</param>
    /// <param name="secondSide">Triangular second side value.</param>
    /// <param name="thirdSide">Triangular third side value.</param>
    [Theory]
    [InlineData(10.0, 10.0, -10.0)]
    [InlineData(-1.0, 16.0, 4.0)]
    [InlineData(0.0, 0.0, 0.0)]
    [InlineData(10.0, 9.0, 20.0)]
    [InlineData(1.0, 16.0, 12.0)]
    [InlineData(4.0, 1.0, 8.0)]
    public void Triangular_WhenConstructWithNotCorrectParameters_DomainModelException(
        double firstSide,
        double secondSide,
        double thirdSide
    ) {
        var exception = Record.Exception(
            () => new Triangular(
                firstSide,
                secondSide,
                thirdSide
            )
        );

        Assert.IsType<DomainModelException>(exception);
    }

    /// <summary>
    /// Triangular get correct type when triangular sides has correct value testing method.
    /// </summary>
    /// <param name="firstSide">Triangular first side value.</param>
    /// <param name="secondSide">Triangular second side value.</param>
    /// <param name="thirdSide">Triangular third side value.</param>
    /// <param name="triangularType">Triangular type value.</param>
    [Theory]
    [InlineData(3.0, 4.0, 5.0, ShapeType.RightTriangle)]
    [InlineData(5.0, 12.0, 13.0, ShapeType.RightTriangle)]
    [InlineData(4.0, 3.0, 5.0, ShapeType.RightTriangle)]
    [InlineData(4, 8, 7, ShapeType.AcuteTriangle)]
    [InlineData(0.5, 0.25, 0.45, ShapeType.AcuteTriangle)]
    [InlineData(8, 4, 7, ShapeType.AcuteTriangle)]
    [InlineData(5.0, 7.0, 9.0, ShapeType.ObtuseTriangle)]
    [InlineData(2.0, 3.0, 4.0, ShapeType.ObtuseTriangle)]
    [InlineData(9.0, 5.0, 6.0, ShapeType.ObtuseTriangle)]
    public void GetTriangularType_WhenTriangularSidesIsCorrect_ReturnsProperTriangularType(
        double firstSide,
        double secondSide,
        double thirdSide,
        ShapeType triangularType
    ) {
        var triangular = new Triangular(
            firstSide,
            secondSide,
            thirdSide
        );

        Assert.Equal(triangular.FirstSide, firstSide);
        Assert.Equal(triangular.SecondSide, secondSide);
        Assert.Equal(triangular.ThirdSide, thirdSide);
        Assert.Equal(triangular.GetShapeType(), triangularType);
    }
}