//-----------------------------------------------------------------------
// <copyright file="CAMLQueryFilter.cs" company="Noor">
// Copyright (c) 2013 Noor.
// All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CAMLator
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Type of Query
    /// </summary>
    public enum QueryType
    {
        /// <summary>
        /// Equal filter query type
        /// </summary>
        Equal,

        /// <summary>
        /// Not Equal filter query type
        /// </summary>
        NotEqual,

        /// <summary>
        /// Greater than filter query type
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Greater than or equal filter query type
        /// </summary>
        GreaterThanOrEqual,

        /// <summary>
        /// Lower than filter query type
        /// </summary>
        LowerThan,

        /// <summary>
        /// Lower than or equal filter query type
        /// </summary>
        LowerThanOrEqual,

        /// <summary>
        /// Begins with filter query type
        /// </summary>
        BeginsWith,

        /// <summary>
        /// Contains filter query type
        /// </summary>
        Contains,

        /// <summary>
        /// Date Ranges Overlap filter query type
        /// </summary>
        DateRangesOverlap
    }

    /// <summary>
    /// Type of field for which the filter is being instantiated
    /// </summary>
    public enum FieldType
    {
        /// <summary>
        /// Single line of text field
        /// </summary>
        Text,

        /// <summary>
        /// Multiline text field
        /// </summary>
        Note,

        /// <summary>
        /// People or group (single) field
        /// </summary>
        User,

        /// <summary>
        /// People or group (multi) field
        /// </summary>
        UserMulti,

        /// <summary>
        /// Yes / No field
        /// </summary>
        Boolean,

        /// <summary>
        /// Number field
        /// </summary>
        Counter,

        /// <summary>
        /// Calculated field
        /// </summary>
        Computed
    }

    /// <summary>
    /// Represents an instant of CAML filter. Typically CAML filter is any entity expressed in CAML that can be 'OR-ed' or 'AND-ed'
    /// </summary>
    public class CAMLQueryFilter
    {
        /// <summary>
        /// Gets or sets the EQ query mark up
        /// </summary>
        protected static readonly string QueryEQMarkUp = "<Eq>{0}{1}</Eq>";

        /// <summary>
        /// Gets or sets the NEQ query mark up
        /// </summary>
        protected static readonly string QueryNEQMarkUp = "<Neq>{0}{1}</Neq>";

        /// <summary>
        /// Gets or sets the GT query mark up
        /// </summary>
        protected static readonly string QueryGTMarkUp = "<Gt>{0}{1}</Gt>";

        /// <summary>
        /// Gets or sets the GEQ query mark up
        /// </summary>
        protected static readonly string QueryGEQMarkUp = "<Geq>{0}{1}</Geq>";

        /// <summary>
        /// Gets or sets the LT query mark up
        /// </summary>
        protected static readonly string QueryLTMarkUp = "<Lt>{0}{1}</Lt>";

        /// <summary>
        /// Gets or sets the LEQ query mark up
        /// </summary>
        protected static readonly string QueryLEQMarkUp = "<Leq>{0}{1}</Leq>";

        /// <summary>
        /// Gets or sets the Begins with query mark up
        /// </summary>
        protected static readonly string QueryBEGINSWITHMarkUp = "<BeginsWith>{0}{1}</BeginsWith>";

        /// <summary>
        /// Gets or sets the Contains query mark up
        /// </summary>
        protected static readonly string QueryCONTAINSMarkUp = "<Contains>{0}{1}</Contains>";

        /// <summary>
        /// Gets or sets the Date Ranges Overlap query mark up
        /// </summary>
        protected static readonly string QueryDATERANGESOVERLAPMarkUp = "<DateRangesOverlap>{0}{1}</DateRangesOverlap>";

        /// <summary>
        /// Gets or sets the 'Is Null' query mark up
        /// </summary>
        protected static readonly string QueryISNULLMarkUp = "<IsNull>{0}</IsNull>";

        /// <summary>
        /// Gets or sets the 'Is not null' query mark up
        /// </summary>
        protected static readonly string QueryISNOTNULLMarkUp = "<IsNotNull>{0}</IsNotNull>";

        /// <summary>
        /// Gets or sets the Field reference element mark up
        /// </summary>
        protected static readonly string QueryFIELDREFMarkUp = "<FieldRef Name=\"{0}\" />";

        /// <summary>
        /// Gets or sets the Value element mark up
        /// </summary>
        protected static readonly string QueryVALUEMarkUp = "<Value Type=\"{1}\">{2}</Value>";

        /// <summary>
        /// Gets or sets the Query text
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Converts the value of the query being built into its equivalent string representation
        /// </summary>
        /// <returns>Query string</returns>
        public override string ToString()
        {
            return this.Query;
        }

        /// <summary>
        /// Gets the Mark Up format for the given Query Type. (E.g.: Returns "&lt;EQ&gt;{0}{1}&lt;/EQ&gt;")
        /// </summary>
        /// <param name="queryType">Type of query</param>
        /// <returns>Mark up format of the Query Type</returns>
        protected string GetQueryTypeMarkUp(QueryType queryType)
        {            
            try
            {
                string queryTypeMarkUp = string.Empty;
                switch (queryType)
                {
                    case QueryType.Equal: queryTypeMarkUp = QueryEQMarkUp;
                        break;
                    case QueryType.NotEqual: queryTypeMarkUp = QueryNEQMarkUp;
                        break;
                    case QueryType.GreaterThan: queryTypeMarkUp = QueryGTMarkUp;
                        break;
                    case QueryType.GreaterThanOrEqual: queryTypeMarkUp = QueryGEQMarkUp;
                        break;
                    case QueryType.LowerThan: queryTypeMarkUp = QueryLTMarkUp;
                        break;
                    case QueryType.LowerThanOrEqual: queryTypeMarkUp = QueryLEQMarkUp;
                        break;
                    case QueryType.BeginsWith: queryTypeMarkUp = QueryBEGINSWITHMarkUp;
                        break;
                    case QueryType.Contains: queryTypeMarkUp = QueryCONTAINSMarkUp;
                        break;
                    case QueryType.DateRangesOverlap: queryTypeMarkUp = QueryDATERANGESOVERLAPMarkUp;
                        break;
                    default: queryTypeMarkUp = QueryEQMarkUp;
                        break;
                }

                return queryTypeMarkUp;
            }
            catch (Exception ex)
            {                
                throw ex;
            }            
        }
    }
}