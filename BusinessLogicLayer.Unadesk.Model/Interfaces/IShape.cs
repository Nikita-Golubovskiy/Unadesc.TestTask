using BusinessLogicLayer.Unadesk.Model.Enumeration;

namespace BusinessLogicLayer.Unadesk.Model.Interfaces;

/// <summary>
/// Shape interface.
/// </summary>
public interface IShape
{
    /// <summary>
    /// Shape type getting method.
    /// </summary>
    /// <returns>Shape type value.</returns>
    public ShapeType GetShapeType();
}