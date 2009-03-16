// This file is part of the re-motion Core Framework (www.re-motion.org)
// Copyright (C) 2005-2008 rubicon informationstechnologie gmbh, www.rubicon.eu
// 
// The re-motion Core Framework is free software; you can redistribute it 
// and/or modify it under the terms of the GNU Lesser General Public License 
// version 3.0 as published by the Free Software Foundation.
// 
// re-motion is distributed in the hope that it will be useful, 
// but WITHOUT ANY WARRANTY; without even the implied warranty of 
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with re-motion; if not, see http://www.gnu.org/licenses.
// 
using System.Linq.Expressions;
using Remotion.Utilities;

namespace Remotion.Data.Linq.Clauses
{
  public class GroupClause : ISelectGroupClause
  {
    private readonly Expression _groupExpression;
    private readonly Expression _byExpression;

    public GroupClause (IClause previousClause,Expression groupExpression, Expression byExpression)
    {
      ArgumentUtility.CheckNotNull ("groupExpression", groupExpression);
      ArgumentUtility.CheckNotNull ("byExpression", byExpression);
      ArgumentUtility.CheckNotNull ("previousClause", previousClause);

      _groupExpression = groupExpression;
      _byExpression = byExpression;
      PreviousClause = previousClause;
    }

    public IClause PreviousClause { get; private set; }

    public Expression GroupExpression
    {
      get { return _groupExpression; }
    }

    public Expression ByExpression
    {
      get { return _byExpression; }
    }

    public void Accept (IQueryVisitor visitor)
    {
      ArgumentUtility.CheckNotNull ("visitor", visitor);
      visitor.VisitGroupClause (this);
    }

    public GroupClause Clone (IClause newPreviousClause)
    {
      return new GroupClause (newPreviousClause, GroupExpression, ByExpression);
    }

    ISelectGroupClause ISelectGroupClause.Clone (IClause newPreviousClause)
    {
      return Clone (newPreviousClause);
    }
  }
}
