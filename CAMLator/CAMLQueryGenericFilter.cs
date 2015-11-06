//-----------------------------------------------------------------------
// <copyright file="CAMLQueryGenericFilter.cs" company="Noor">
// Copyright (c) 2013 Noor.
// All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CAMLator
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an instant of CAML filter that queries all non-DateTime field types
    /// </summary>
    public class CAMLQueryGenericFilter : CAMLQueryFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CAMLQueryGenericFilter"/> class.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="fieldType">Type of the field.</param>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="queryType">Type of the query.</param>
        public CAMLQueryGenericFilter(string fieldName, FieldType fieldType, string fieldValue, QueryType queryType)
        {
            try
            {
                this.FieldName = fieldName;
                this.FieldType = fieldType;
                this.FieldValue = fieldValue;
                string filterMarkUp = string.Empty;
                filterMarkUp = string.Format(this.GetQueryTypeMarkUp(queryType), CAMLQueryFilter.QueryFIELDREFMarkUp, CAMLQueryFilter.QueryVALUEMarkUp);
                this.Query = string.Format(filterMarkUp, fieldName, fieldType.ToString(), fieldValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CAMLQueryGenericFilter"/> class.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="isNull">if set to <c>true</c> [is null].</param>
        public CAMLQueryGenericFilter(string fieldName, bool isNull)
        {
            try
            {
                string filterMarkUp = string.Format(isNull ? QueryISNULLMarkUp : QueryISNOTNULLMarkUp, QueryFIELDREFMarkUp);
                this.Query = string.Format(filterMarkUp, fieldName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>
        /// The name of the field.
        /// </value>
        public string FieldName { get; set; }

        /// <summary>
        /// Gets or sets the type of the field.
        /// </summary>
        /// <value>
        /// The type of the field.
        /// </value>
        public FieldType FieldType { get; set; }

        /// <summary>
        /// Gets or sets the field value.
        /// </summary>
        /// <value>
        /// The field value.
        /// </value>
        public string FieldValue { get; set; }
    }
}
