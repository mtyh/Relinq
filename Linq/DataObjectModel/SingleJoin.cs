using Rubicon.Utilities;

namespace Rubicon.Data.Linq.DataObjectModel
{
  public struct SingleJoin
  {
    public Column RightColumn { get; private set; }
    public Column LeftColumn { get; private set; }

    public SingleJoin (Column leftColumn, Column rightColumn) : this()
    {
      ArgumentUtility.CheckNotNull ("leftColumn", leftColumn);
      ArgumentUtility.CheckNotNull ("rightColumn", rightColumn);

      LeftColumn = leftColumn;
      RightColumn = rightColumn;
    }

    public Table LeftSide
    {
      get { return LeftColumn.Table; }
    }

    public Table RightSide
    {
      get { return RightColumn.Table; }
    }

    public override string ToString ()
    {
      return string.Format ("({0} left join {1} on {2} = {3})", RightSide, LeftSide, RightColumn, LeftColumn);
    }
  }
}