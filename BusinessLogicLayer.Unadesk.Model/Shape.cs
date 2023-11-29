using BusinessLogicLayer.Unadesk.Model.Enumeration;
using BusinessLogicLayer.Unadesk.Model.Interfaces;

namespace BusinessLogicLayer.Unadesk.Model;

/// <summary>
/// Shape entity model class.
/// </summary>
public abstract class Shape : IShape
{
    /// <summary>
    /// Shape type getting method.
    /// </summary>
    /// <returns>Shape type value.</returns>
    public abstract ShapeType GetShapeType();

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        var shapeType = this.GetShapeType();

        return $"Shape type: { shapeType }";
    }
}