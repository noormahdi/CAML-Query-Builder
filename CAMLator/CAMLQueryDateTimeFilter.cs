//-----------------------------------------------------------------------
// <copyright file="CAMLQueryDateTimeFilter.cs" company="Noor">
// Copyright (c) 2013 Noor.
// All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CAMLator
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an instant of CAML filter that queries DateTime field types
    /// </summary>
    public class CAMLQueryDateTimeFilter : CAMLQueryFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CAMLQueryDateTimeFilter"/> class.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="date">The date.</param>
        /// <param name="queryType">Type of the query.</param>
        /// <param name="includeTimeValue">if set to <c>true</c> [include time value].</param>
        public CAMLQueryDateTimeFilter(string fieldName, DateTime date, QueryType queryType, bool includeTimeValue = false)
        {
            try
            {
                string queryVALUEDateTimeMarkUp = "<Value IncludeTimeValue=\"{1}\" Type=\"{2}\">{3}</Value>";
                string filterMarkUp = string.Format(GetQueryTypeMarkUp(queryType), QueryFIELDREFMarkUp, queryVALUEDateTimeMarkUp);
                this.Query = string.Format(filterMarkUp, fieldName, includeTimeValue.ToString(), "DateTime", date.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
